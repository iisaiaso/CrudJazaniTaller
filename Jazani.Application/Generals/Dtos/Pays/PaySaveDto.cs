using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Pays
{
    public class PaySaveDto
    {
        
        public int Year { get; set; }
        public string? ReceiptNumber { get; set; }
        public decimal IndividualCost { get; set; }
        public decimal AmountPaid { get; set; }
        public int PeriodTypeId { get; set; }
        public int FinancialentityId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int MiningConcessionId { get; set; }
        public int ConceptId { get; set; }
        public string? Description { get; set; }
        public decimal AvailableArea { get; set; }
         
    }
}
