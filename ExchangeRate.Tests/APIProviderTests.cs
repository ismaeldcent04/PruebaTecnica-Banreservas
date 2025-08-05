using ExchangeRate.Models;
using ExchangeRate.Providers;

namespace ExchangeRate.Tests
{
    [TestClass]
    public class APIProviderTests
    {
        [TestMethod]
        public async Task Convert_ReturnsSuccessfulResult()
        {
           
            var provider = new APIProvider1();

            var request = new ExchangeRequest("USD", "DOP", 9000);
            
            var result = await provider.Convert(request);

            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual("APIProvider1", result.Provider);
            Assert.IsTrue(result.ExchangeRate > 0);
        }
    }
}
