using ExchangeRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Providers
{
    public interface IProvider
    {
        Task<ExchangeResult> Convert(ExchangeRequest exchangeRequest);
    }
}
