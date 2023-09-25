using EntitiesShared.POSManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.POSControllers.Validators
{
    public class CheckOutSalesTransactionValidator : AbstractValidator<SaleTransactionModel>
    {
        public CheckOutSalesTransactionValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.TransactionType).NotNull();
            RuleFor(x => x.TicketNumber).NotEmpty();
            RuleFor(x => x.CurrentUser).NotEmpty();
            RuleFor(x => x.SubTotalAmount).NotEmpty();
            RuleFor(x => x.TotalAmount).NotEmpty();
            RuleFor(x => x.CustomerCashAmount).NotEmpty();
            RuleFor(x => x.CustomerChangeAmount).NotEmpty();
            RuleFor(x => x.CustomerDueAmount).NotEmpty();
            RuleFor(x => x.TableNumber).NotEmpty();
            RuleFor(x => x.TransStatus).NotNull();
        }
    }
}
