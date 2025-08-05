using ExchangeRate.Models;
using ExchangeRate.Providers;

namespace ExchangeRate.Test
{
    [TestClass]
    public sealed class APIProviderTest1
    {
        [TestMethod]
        public async Task Convert_ReturnsSuccessfulResult()
        {
           
            var provider = new APIProvider2();

            var request = new ExchangeRequest("USD", "DOP", 100);
          
            var result = await provider.Convert(request);

            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual("exchangerate-api", result.Provider);
            Assert.IsTrue(result.ExchangeRate > 0);
        }
    }
}
