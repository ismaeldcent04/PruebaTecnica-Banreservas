

using ExchangeRate.Models;
using ExchangeRate.Providers;

var request = new ExchangeRequest("USD", "DOP", 1000);

var provider = new APIProvider1();
var provider2 = new APIProvider2();
var provider3 = new APIProvider3();

var result1 = await provider.Convert(request);
var result2 = await provider2.Convert(request);
var result3 = await provider3.Convert(request);

Console.WriteLine($"Proveedor1: {Math.Round(result1.ExchangeRate,2)}");
Console.WriteLine($"Proveedor2: {Math.Round(result2.ExchangeRate, 2)}");
Console.WriteLine($"Proveedor3: {Math.Round(result3.ExchangeRate, 2)}");
