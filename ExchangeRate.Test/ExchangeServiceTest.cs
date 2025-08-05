using ExchangeRate.Lib.Services;
using ExchangeRate.Models;
using ExchangeRate.Providers;
using Moq;

namespace ExchangeRate.Test
{
    [TestClass]
    public sealed class ExchangeServiceTest
    {
        [TestMethod]
        public async Task ConvertAsync_ReturnsBestExchangeRate()
        {
            // Arrange: mock de proveedores
            var provider1 = new Mock<IProvider>();
            provider1.Setup(p => p.Convert(It.IsAny<ExchangeRequest>()))
                     .ReturnsAsync(new ExchangeResult { Provider = "P1", ExchangeRate = 50, IsSuccessful = true });

            var provider2 = new Mock<IProvider>();
            provider2.Setup(p => p.Convert(It.IsAny<ExchangeRequest>()))
                     .ReturnsAsync(new ExchangeResult { Provider = "P2", ExchangeRate = 55, IsSuccessful = true });

            var provider3 = new Mock<IProvider>();
            provider3.Setup(p => p.Convert(It.IsAny<ExchangeRequest>()))
                     .ReturnsAsync(new ExchangeResult { Provider = "P3", ExchangeRate = 52, IsSuccessful = true });

            var service = new ExchangeService(new List<IProvider> { provider1.Object, provider2.Object, provider3.Object });

            var request = new ExchangeRequest("USD", "DOP", 1);
         

            // Act
            var result = await service.GetBestExchangeRate(request);

            // Assert
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual("P2", result.Provider);
            Assert.AreEqual(55, result.ExchangeRate);
        }
    }
}
