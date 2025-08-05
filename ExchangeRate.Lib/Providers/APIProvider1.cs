using ExchangeRate.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Providers
{
    public class APIProvider1 : IProvider
    {
     
        public async Task<ExchangeResult> Convert(ExchangeRequest exchangeRequest)
        {
        

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://v6.exchangerate-api.com/v6/793a391cdb1efe832d463984/pair/{exchangeRequest.SourceCurrency}/{exchangeRequest.TargetCurrency}/{exchangeRequest.Amount}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<APIResponse1>(stringResponse);

                if (apiResponse != null && apiResponse.Result == "success")
                {
                    return new ExchangeResult
                    {
                        Provider = "exchangerate-api",
                        ExchangeRate = Math.Round(apiResponse.ConversionResult,2),
                        IsSuccessful = true
                    };
                }

                return new ExchangeResult
                {
                    Provider = "exchangerate-api",
                    ExchangeRate = 0,
                    IsSuccessful = false
                };


            }
            catch (Exception ex)
            {
                return new ExchangeResult
                {
                    Provider = "exchangerate-api",
                    ExchangeRate = 0,
                    IsSuccessful = false
                };

            }

        }
    }
}