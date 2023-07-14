using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingApp.Tests.Doubles;

namespace TradingApp.Tests
{
    [TestClass]
    internal class AccountManagerTests
    {
        [TestMethod]
        public void GetTotalCashShouldReturnAccountBalanceInUSD()
        {
            // arrange
            var dataServiceMock = // Mock.Of<ITradingDataService>();
                                    new Mock<ITradingDataService>();
            dataServiceMock
                .Setup(ds => ds.RetreiveInfo(
                    It.IsAny<string>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>()))
                .Returns(new SymbolInfo("MSFT"));

            var accountManager = new AccountManager(
                100,
                dataServiceMock.Object,
                new SpyTradingEngine(new StubTradingEngine()));

            // act
            var actualBalance = accountManager.GetTotalCash();

            // assert
            Assert.AreEqual(100, actualBalance);
            dataServiceMock
                .Verify(
                    ds => ds.RetreiveInfo(
                        It.IsAny<string>(),
                        It.IsAny<TimeSpan>(),
                        It.IsAny<TimeSpan>()),
                    Times.Never());
        }
    }
}
