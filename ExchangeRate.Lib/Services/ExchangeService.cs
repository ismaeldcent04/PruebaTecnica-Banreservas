using ExchangeRate.Models;
using ExchangeRate.Providers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Lib.Services
{
    public class ExchangeService : IExchangeService
    {

        private List<IProvider> _providers;


        public ExchangeService(IEnumerable<IProvider> providers)
        {
            _providers = providers.ToList();
       
        }

        public async Task<ExchangeResult> GetBestExchangeRate(ExchangeRequest request)
        {
            try
            {
                var results = new List<ExchangeResult>();

                foreach (var provider in _providers)
                {
                    var result = await provider.Convert(request);

                    if (result.IsSuccessful)
                    {
                        results.Add(result);
                    }
                }

                if (results.Any())
                {
                    return results.OrderByDescending(x => x.ExchangeRate).FirstOrDefault();
                }


                return new ExchangeResult
                {
                    Provider = "None",
                    ExchangeRate = 0,
                    IsSuccessful = false,

                };
            }
            catch (Exception ex)
            {
                
                return new ExchangeResult
                {
                    Provider = "None",
                    ExchangeRate = 0,
                    IsSuccessful = false,

                };
            }
           
        }


    }
}
