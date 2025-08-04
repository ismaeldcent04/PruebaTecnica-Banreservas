using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Models
{
    public class ExchangeRequest
    {
        public string SourceCurrency {  get; set; }

        public string TargetCurrency { get; set; }

        public decimal Amount { get; set; }
    }
}
