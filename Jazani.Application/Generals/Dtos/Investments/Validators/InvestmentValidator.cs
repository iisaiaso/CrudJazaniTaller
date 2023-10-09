using FluentValidation;

namespace Jazani.Application.Generals.Dtos.Investments.Validators
{
    public class InvestmentValidator : AbstractValidator<InvestmentSaveDto>
    {
        public InvestmentValidator() 
        {
            RuleFor(x => x.AmountInvestd)
            .NotNull()
            .NotEmpty();

            RuleFor(x => x.MiningConcessionId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.InvestmentTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CurrencyTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.HolderId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DeclaredTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PeriodTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(200);

            RuleFor(x => x.MonthName)
                .MaximumLength(25);

        }
    }
}
