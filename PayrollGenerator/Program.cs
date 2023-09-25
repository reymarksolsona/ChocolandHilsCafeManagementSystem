using System;
using System.IO;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayrollGenerator.Models;
using Shared;
using Serilog;
using PayrollGenerator.Services;
using Hangfire.MySql;
using System.Transactions;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.EmployeeManagement.Implementations;
using DataAccess.Data.PayrollManagement.Contracts;
using DataAccess.Data.PayrollManagement.Implementations;
using DapperGenericDataManager;
using DataAccess;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Implementations;
using PDFReportGenerators;
using WkHtmlToPdfDotNet.Contracts;
using WkHtmlToPdfDotNet;
using Topshelf;
using DataAccess.Data.POSManagement.Contracts;
using DataAccess.Data.POSManagement.Implementations;
using GovContributionCalculators.GovContributionCalculator;

namespace PayrollGenerator
{
    public class HangFireBackgroundService
    {
        private BackgroundJobServer server;

        public bool Start()
        {

            this.server = new BackgroundJobServer();

            return true;
        }

        public bool Stop()
        {
            this.server.Dispose();

            return true;
        }
    }


    public class ContainerJobActivator : JobActivator
    {
        private IHost _container;

        public ContainerJobActivator(IHost container)
        {
            _container = container;
        }

        public override object ActivateJob(Type type)
        {
            var svc = ActivatorUtilities.CreateInstance(_container.Services, type);
            return svc;
        }
    }


    class Program
    {
        static IConfigurationRoot GetConfigurationBuilder()
        {
            var Confbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return Confbuilder;
        }

        static IHost ConfigureServices()
        {
            var ConfBuilder = GetConfigurationBuilder();

            var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
                    services.Configure<PayrollSettings>(ConfBuilder.GetSection(nameof(PayrollSettings)));
                    services.Configure<DBConnectionSettings>(ConfBuilder.GetSection(nameof(DBConnectionSettings)));
                    services.Configure<HangfireConfig>(ConfBuilder.GetSection(nameof(HangfireConfig)));
                    services.AddTransient<IDbConnectionFactory, MySQLConnection>(); // database settings, including connection string
                    services.AddTransient<IBranchData, BranchData>();
                    services.AddTransient<IEmployeePositionData, EmployeePositionData>();
                    services.AddTransient<IEmployeeAttendanceData, EmployeeAttendanceData>();
                    services.AddTransient<IEmployeeBenefitData, EmployeeBenefitData>();
                    services.AddTransient<IEmployeeData, EmployeeData>();
                    services.AddTransient<IEmployeeDeductionData, EmployeeDeductionData>();
                    services.AddTransient<ISpecificEmployeeBenefitData, SpecificEmployeeBenefitData>();
                    services.AddTransient<ISpecificEmployeeDeductionData, SpecificEmployeeDeductionData>();
                    services.AddTransient<IEmployeeLeaveData, EmployeeLeaveData>();
                    services.AddTransient<IEmployeePayslipBenefitData, EmployeePayslipBenefitData>();
                    services.AddTransient<IEmployeePayslipData, EmployeePayslipData>();
                    services.AddTransient<IEmployeePayslipDeductionData, EmployeePayslipDeductionData>();
                    services.AddTransient<IEmployeeGovernmentContributionData, EmployeeGovernmentContributionData>();
                    services.AddTransient<IEmployeeShiftData, EmployeeShiftData>();
                    services.AddTransient<IEmployeeShiftDayData, EmployeeShiftDayData>();
                    services.AddTransient<IEmployeeGovtIdCardData, EmployeeGovtIdCardData>();
                    services.AddTransient<IPayslipGenerator, PayslipGenerator>();
                    services.AddTransient<ILeaveTypeData, LeaveTypeData>();
                    services.AddTransient<IGovernmentAgencyData, GovernmentAgencyData>();
                    services.AddTransient<IEmployeePayslipPDFReport, EmployeePayslipPDFReport>();
                    services.AddTransient<IPayrollPDFReport, PayrollPDFReport>();
                    services.AddTransient<ICashRegisterCashOutTransactionData, CashRegisterCashOutTransactionData>();
                    services.AddTransient<IEmployeeCashAdvanceRequestData, EmployeeCashAdvanceRequestData>();

                    services.AddTransient<SSSContributionCalculator>();
                    services.AddTransient<WTaxCalculator>();
                    services.AddTransient<PagIbigContributionCalculator>();
                    services.AddTransient<PhilHealthContributionCalculator>();
                    //services.AddTransient<IAttendancePDFReport, AttendancePDFReport>();
                })
                .UseSerilog()
                .Build();

            return host;
        }

        static void Main(string[] args)
        {

            var ConfBuilder = GetConfigurationBuilder();
            var host = ConfigureServices();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(ConfBuilder)
                .Enrich.FromLogContext()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var hangfireConfig = ConfBuilder.GetSection(nameof(HangfireConfig)).Get<HangfireConfig>();

            GlobalConfiguration.Configuration
                .UseActivator(new ContainerJobActivator(host))
                .UseStorage(new MySqlStorage(
                    hangfireConfig.ConnectionString,
                    new MySqlStorageOptions
                    {
                        TransactionIsolationLevel = IsolationLevel.ReadCommitted,
                        QueuePollInterval = TimeSpan.FromSeconds(15),
                        JobExpirationCheckInterval = TimeSpan.FromHours(1),
                        CountersAggregateInterval = TimeSpan.FromMinutes(5),
                        PrepareSchemaIfNecessary = true,
                        DashboardJobListLimit = 50000,
                        TransactionTimeout = TimeSpan.FromMinutes(1),
                        TablesPrefix = "hangfire"
                    }));

            var payslipGenerator = ActivatorUtilities.CreateInstance<PayslipGenerator>(host.Services);

            RecurringJob.AddOrUpdate(() => payslipGenerator.GeneratePayslip(), Cron.Daily);

            HostFactory.Run(configure =>
            {
                configure.Service<HangFireBackgroundService>(service =>
                {
                    service.ConstructUsing(s => new HangFireBackgroundService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("PayrollGeneratorBackgroundService");
                configure.SetDisplayName("PayrollGeneratorBackgroundService");
                configure.SetDescription("Chonoland Hils Cafe Management system payroll generator background service.");
            });

            // BackgroundJob.Enqueue(() => payslipGenerator.GeneratePayslip());
            //using (var server = new BackgroundJobServer())
            //{
            //    Log.Logger.Information("Hangfire server started...");
            //    Console.ReadLine();
            //}
        }

    }
}
