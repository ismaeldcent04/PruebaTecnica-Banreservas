using ExchangeRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Providers
{
    public class APIProvider2 : IProvider
    {
        public async Task<ExchangeResult> Convert(ExchangeRequest exchangeRequest)
        {
            var result = new ExchangeResult();

            return result;
        }
    }
}