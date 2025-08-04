using ExchangeRate.Lib.Models;
using ExchangeRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRate.Providers
{
    public class APIProvider2 : IProvider
    {
        public async Task<ExchangeResult> Convert(ExchangeRequest exchangeRequest)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.floatrates.com/daily/{exchangeRequest.SourceCurrency}.xml");
                var content = new StringContent("", null, "text/plain");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();

                var serializer = new XmlSerializer(typeof(APIResponse2));
                var result = (APIResponse2)serializer.Deserialize(stream);

                var item = result?.Items.FirstOrDefault(x => x.TargetCurrency.ToUpper() == exchangeRequest.TargetCurrency.ToUpper());

                if (item != null)
                {
                    return new ExchangeResult
                    {
                        Provider = "API2",
                        ExchangeRate = item.ExchangeRate * exchangeRequest.Amount,
                        IsSuccessful = true,

                    };
                }

                return new ExchangeResult
                {
                    Provider = "API2",
                    ExchangeRate = 0,
                    IsSuccessful = false,
                };
            }
            catch (Exception)
            {
                return new ExchangeResult
                {
                    Provider = "API2",
                    ExchangeRate = 0,
                    IsSuccessful = false,
                };

            }
            

           
        }
    }
}