using ExchangeRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Lib.Services
{
    public interface IExchangeService
    {
        Task<ExchangeResult> GetBestExchangeRate(ExchangeRequest request);
    }
}
