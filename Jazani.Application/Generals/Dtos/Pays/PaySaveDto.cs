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
        public int FinancialentityId { get; set; }
    }
}
