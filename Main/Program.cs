using DapperGenericDataManager;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.EmployeeManagement.Implementations;
using Main.Controllers.UserManagementControllers;
using DataAccess.Data.UserManagement.Contracts;
using DataAccess.Data.UserManagement.Implementations;
using Shared.Helpers;
using Main.Controllers.EmployeeManagementControllers.Validator;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.EmployeeManagementControllers;
using AutoMapper;
using Main.Forms.EmployeeManagementForms;
using Main.Forms.OtherDataForms;
using Main.Forms.PayrollForms;
using Main.Controllers.OtherDataController.Validator;
using Main.Controllers.OtherDataController;
using Main.Controllers.OtherDataController.ControllerInterface;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Implementations;
using Main.Forms.UserManagementForms;
using Main.Controllers.UserManagementControllers.Validator;
using Main.Forms.AttendanceTerminal;
using DataAccess.Data.PayrollManagement.Contracts;
using DataAccess.Data.PayrollManagement.Implementations;
using WkHtmlToPdfDotNet.Contracts;
using WkHtmlToPdfDotNet;
using PDFReportGenerators;
using DataAccess.Data.InventoryManagement.Contracts;
using DataAccess.Data.InventoryManagement.Implementations;
using Main.Forms.InventoryManagementForms;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Main.Controllers.InventoryControllers;
using Main.Controllers.InventoryControllers.Validator;
using Main.Forms.POSManagementForms;
using DataAccess.Data.POSManagement.Contracts;
using DataAccess.Data.POSManagement.Implementations;
using Main.Controllers.POSControllers.ControllerInterface;
using Main.Controllers.POSControllers;
using Main.Controllers.POSControllers.Validators;
using Main.Forms.SalesReport;
using Main.Forms.RequestsForm;
using Main.Controllers.RequestControllers.Validators;
using Main.Controllers.RequestControllers.ControllerInterface;
using Main.Controllers.RequestControllers;
using GovContributionCalculators.GovContributionCalculator;

namespace Main
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            var ConfBuilder = GetConfigurationBuilder();

            ConfigureServices(services, ConfBuilder);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
                //var mainFrm = serviceProvider.GetRequiredService<MainFrm>();
                var logger = serviceProvider.GetRequiredService<ILogger<MainFrm>>();

                try
                {
                    Application.Run(loginFrm);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unexpected application error, kindly visit system logs and report this error to developer: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logger.LogError($"{ex.Message} {ex.StackTrace}");
                }
            }
        }

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


        private static void UnhandleExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show($"Unhandle exception caught: { e.Message } - Runtime terminating: {args.IsTerminating}");
        }


        private static void ConfigureServices (ServiceCollection services, IConfigurationRoot confBuilder)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandleExceptionHandler);
            services.AddAutoMapper(currentDomain.GetAssemblies());

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            // settings
            services.Configure<DBConnectionSettings>(confBuilder.GetSection(nameof(DBConnectionSettings)));
            services.Configure<PayrollSettings>(confBuilder.GetSection(nameof(PayrollSettings)));
            services.Configure<OtherSettings>(confBuilder.GetSection(nameof(OtherSettings)));
            services.AddTransient<IDbConnectionFactory, MySQLConnection>(); // database settings, including connection string

            services.AddSingleton<Sessions>(); // application state or session
            services.AddSingleton<POSState>();
            services.AddSingleton<Hashing>();
            services.AddSingleton<DecimalMinutesToHrsConverter>();
            services.AddSingleton<UOMConverter>();

            // Data Access services
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IRoleData, RoleData>();
            services.AddTransient<IUserRoleData, UserRoleData>();

            services.AddTransient<SSSContributionCalculator>();
            services.AddTransient<WTaxCalculator>();
            services.AddTransient<PagIbigContributionCalculator>();
            services.AddTransient<PhilHealthContributionCalculator>();

            // Employee Management module: services:
            services.AddTransient<INumberOfWorkingDaysInAMonthData, NumberOfWorkingDaysInAMonthData>();
            services.AddTransient<IHolidayData, HolidayData>();
            services.AddTransient<IEmployeeAttendanceData, EmployeeAttendanceData>();
            services.AddTransient<IEmployeeBenefitData, EmployeeBenefitData>();
            services.AddTransient<IEmployeeDeductionData, EmployeeDeductionData>();
            services.AddTransient<ISpecificEmployeeBenefitData, SpecificEmployeeBenefitData>();
            services.AddTransient<ISpecificEmployeeDeductionData, SpecificEmployeeDeductionData>();
            services.AddTransient<IBranchData, BranchData>();
            services.AddTransient<IEmployeePositionData, EmployeePositionData>();
            services.AddTransient<IEmployeeData, EmployeeData>();
            services.AddTransient<IEmployeeLeaveData, EmployeeLeaveData>();
            services.AddTransient<IEmployeePayslipBenefitData, EmployeePayslipBenefitData>();
            services.AddTransient<IEmployeePayslipData, EmployeePayslipData>();
            services.AddTransient<IEmployeePayslipDeductionData, EmployeePayslipDeductionData>();
            services.AddTransient<IEmployeeGovernmentContributionData, EmployeeGovernmentContributionData>();
            services.AddTransient<IEmployeeShiftData, EmployeeShiftData>();
            services.AddTransient<IEmployeeShiftDayData, EmployeeShiftDayData>();
            services.AddTransient<IEmployeeGovtIdCardData, EmployeeGovtIdCardData>();
            services.AddTransient<IWorkforceScheduleData, WorkforceScheduleData>();
            services.AddTransient<IEmployeeCashAdvanceRequestData, EmployeeCashAdvanceRequestData>();
            // Other data management
            services.AddTransient<ILeaveTypeData, LeaveTypeData>();
            services.AddTransient<IGovernmentAgencyData, GovernmentAgencyData>();

            // Invetory and Product management
            services.AddTransient<IIngredientCategoryData, IngredientCategoryData>();
            services.AddTransient<IIngredientData, IngredientData>();
            services.AddTransient<IIngredientInventoryData, IngredientInventoryData>();
            services.AddTransient<IIngInventoryTransactionData, IngInventoryTransactionData>();
            services.AddTransient<IProductCategoryData, ProductCategoryData>();
            services.AddTransient<IProductData, ProductData>();
            services.AddTransient<IProductIngredientData, ProductIngredientData>();
            services.AddTransient<IComboMealData, ComboMealData>();
            services.AddTransient<IComboMealProductData, ComboMealProductData>();

            // POS
            services.AddTransient<IStoreTableData, StoreTableData>();
            services.AddTransient<ISaleTransactionData, SaleTransactionData>();
            services.AddTransient<ISaleTransactionProductData, SaleTransactionProductData>();
            services.AddTransient<ISaleTransactionComboMealData, SaleTransactionComboMealData>();
            services.AddTransient<ISaleTranProdIngInvDeductionsRecordData, SaleTranProdIngInvDeductionsRecordData>();
            services.AddTransient<ISaleTranComboMealIngInvDeductionsRecordData, SaleTranComboMealIngInvDeductionsRecordData>();
            services.AddTransient<ICashRegisterCashOutTransactionData, CashRegisterCashOutTransactionData>();

            // Employee Management
            // validator
            services.AddTransient<EmployeeAddUpdateValidator>();
            services.AddTransient<EmployeeShiftAddUpdateValidator>();
            services.AddTransient<EmployeeLeaveAddUpdateValidator>();
            services.AddTransient<HolidayAddUpdateValidator>();
            services.AddTransient<EmployeePositionAddUpdateValidator>();
            // Other Data:
            // validator
            services.AddTransient<LeaveTypeAddUpdateValidator>();
            services.AddTransient<UserAddUpdateValidator>();
            services.AddTransient<GovernmentAgencyAddUpdateValidator>();
            services.AddTransient<BranchAddUpdateValidator>();
            // Inventory
            services.AddTransient<IngredientAddUpdateValidator>();
            services.AddTransient<IngredientInventoryAddUpdateValidator>();
            services.AddTransient<ProductAddUpdateValidator>();
            services.AddTransient<ProductIngredientAddUpdateValidator>();
            // POS
            services.AddTransient<InitiateNewDineInSalesTransactionValidator>();
            services.AddTransient<InitiateNewTakeOutSalesTransactionValidator>();
            services.AddTransient<CheckOutSalesTransactionValidator>();

            services.AddTransient<EmployeeCashAdvanceRequestValidator>();

            // controllers
            services.AddTransient<IEmployeeBenefitsDeductionsController, EmployeeBenefitsDeductionsController>();
            services.AddTransient<IEmployeeController, EmployeeController>();
            services.AddTransient<IWorkShiftController, WorkShiftController>();
            services.AddTransient<IEmployeeLeaveController, EmployeeLeaveController>();
            services.AddTransient<IHolidayController, HolidayController>();
            services.AddTransient<IWorkforceScheduleController, WorkforceScheduleController>();
            services.AddTransient<ILeaveTypeController, LeaveTypeController>();
            services.AddTransient<IGovernmentController, GovernmentController>();
            services.AddTransient<IBranchInfoController, BranchInfoController>();
            services.AddTransient<IEmployeePositionController, EmployeePositionController>();
            services.AddTransient<IUserController, UserController>();

            services.AddTransient<IIngredientInventoryManager, IngredientInventoryManager>();
            services.AddTransient<IIngredientCategoryController, IngredientCategoryController>();
            services.AddTransient<IIngredientController, IngredientController>();
            services.AddTransient<IIngredientInventoryController, IngredientInventoryController>();
            services.AddTransient<IProductCategoryController, ProductCategoryController>();
            services.AddTransient<IProductController, ProductController>();
            services.AddTransient<IComboMealController, ComboMealController>();

            services.AddTransient<IPOSCommandController, POSCommandController>();
            services.AddTransient<IPOSReadController, POSReadController>();

            services.AddTransient<IEmployeeCashAdvanceRequestController, EmployeeCashAdvanceRequestController>();


            // forms
            services.AddTransient<HomeFrm>();
            services.AddTransient<MainFrm>();
            services.AddTransient<FrmUserManagement>();
            services.AddTransient<LoginFrm>();
            services.AddTransient<FrmMainEmployeeManagement>();
            services.AddTransient<FrmOtherData>();
            services.AddTransient<FrmPayroll>();
            services.AddTransient<AttendanceTerminalForm>();
            services.AddTransient<FrmInventory>();
            services.AddTransient<FrmMainPOSTerminal>();
            services.AddTransient<FrmSalesReport>();
            services.AddTransient<FrmEmployeeRequests>();

            services.AddTransient<IEmployeePayslipPDFReport, EmployeePayslipPDFReport>();
            services.AddTransient<IPayrollPDFReport, PayrollPDFReport>();
            services.AddTransient<IEmployeeGovContributionsReport, EmployeeGovContributionsReport>();
            services.AddTransient<IAttendancePDFReport, AttendancePDFReport>();
            services.AddTransient<IIngredientsInventoryPDFReport, IngredientsInventoryPDFReport>();

            //Add Serilog
            var log = new LoggerConfiguration()
                .ReadFrom.Configuration(confBuilder)
                 .CreateLogger();

            services.AddLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Information);
                x.AddSerilog(logger: log, dispose: true);
            });
        }
    }
}
