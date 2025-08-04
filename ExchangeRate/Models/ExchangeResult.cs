using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Models
{
    public class ExchangeResult
    {
        public string Provider {  get; set; }

        public decimal ExchangeRate { get; set; }

        public bool IsSuccessfull { get; set; }

    }
}
