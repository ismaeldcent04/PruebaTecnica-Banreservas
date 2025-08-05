

using ExchangeRate.Lib.Services;
using ExchangeRate.Models;
using ExchangeRate.Providers;

var providers = new List<IProvider>
{
    new APIProvider1(),
    new APIProvider2(),
    new APIProvider3()
};

var service = new ExchangeService(providers);

var request = new ExchangeRequest("CAD", "JPY", 1500);

var result = await service.GetBestExchangeRate(request);

Console.WriteLine($"The best exchange rate was {result.ExchangeRate} using {result.Provider}");