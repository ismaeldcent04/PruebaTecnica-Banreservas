using ExchangeRate.Lib.Models;
using ExchangeRate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Providers
{
    public class APIProvider3 : IProvider
    {
        public async Task<ExchangeResult> Convert(ExchangeRequest exchangeRequest)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.fastforex.io/convert?api_key=16e69a8f94-63f9785d4d-t0fryy&from={exchangeRequest.SourceCurrency}&to={exchangeRequest.TargetCurrency}&amount={exchangeRequest.Amount}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<APIResponse3>(stringResponse);

                if (string.IsNullOrEmpty(result.Error))
                {
                    return new ExchangeResult
                    {
                        Provider = "API3",
                        ExchangeRate = result.Result.Rate * exchangeRequest.Amount,
                        IsSuccessful = true,
                    };
                }

                return new ExchangeResult
                {
                    Provider = "API3",
                    ExchangeRate = 0,
                    IsSuccessful = false,
                };
            }
            catch (Exception)
            {
                return new ExchangeResult
                {
                    Provider = "API3",
                    ExchangeRate = 0,
                    IsSuccessful = false,
                };
            }
            
        }

    }
}