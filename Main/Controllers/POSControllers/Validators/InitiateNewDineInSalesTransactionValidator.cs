using EntitiesShared.POSManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.POSControllers.Validators
{
    public class InitiateNewDineInSalesTransactionValidator : AbstractValidator<SaleTransactionModel>
    {
        public InitiateNewDineInSalesTransactionValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.TransactionType).NotNull();
            RuleFor(x => x.TicketNumber).NotEmpty();
            RuleFor(x => x.CurrentUser).NotEmpty();
            RuleFor(x => x.TableNumber).NotEmpty();
            RuleFor(x => x.TransStatus).NotNull();
        }
    }
}
