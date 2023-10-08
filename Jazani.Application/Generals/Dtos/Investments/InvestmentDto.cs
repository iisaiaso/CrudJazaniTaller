using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Application.Generals.Dtos.InvestmentConcepts;
using Jazani.Application.Generals.Dtos.InvestmentTypes;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Application.Generals.Dtos.MiningConcessions;
using Jazani.Application.Generals.Dtos.PeriodTypes;

namespace Jazani.Application.Generals.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; }
        public string? Description { get; set; }
        public HolderSimpleDto? Holder { get; set; }
        public InvestmentConceptSimpleDto? InvestmentConcept { get; set; }
        public InvestmentTypeSimpleDto? InvestmentType { get; set; }
        public int CurrencyTypeId { get; set; }
        public MiningConcessionSimpleDto? MiningConcession { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; } 
        public PeriodTypeSimpleDto? PeriodType { get; set; } 
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public string? MonthName { get; set; }
        public int DeclaredTypeId { get; set; }
        public int? DocumentId { get; set; }

    }
}
