using TradingApp.UI.Models;
using TradingApp.UI.Views;

namespace TradingApp.UI
{
    public class UIController
    {
        private readonly ITradingDataService _tradingDataService;
        private readonly IAccountManager _accountManager;

        public UIController(ITradingDataService tradingDataService, IAccountManager accountManager)
        {
            _tradingDataService = tradingDataService;
            _accountManager = accountManager;
        }

        public void Index()
        {
            var view = new IndexView(this);
            view.Show();
        }

        internal void Home(string symbolName, TimeSpan period, TimeSpan granularity)
        {
            var symbolData = _tradingDataService.RetreiveInfo(symbolName, period, granularity);
            var accountBalance = _accountManager.GetTotalCash();

            var homeModel = new HomeModel
            {
                SymbolData = symbolData,
                AccountBalance = accountBalance
            };

            var homeView = new HomeView(this) { Model = homeModel };
            homeView.Show();
        }

        internal void Order(string symbolName)
        {
            // TODO: Разработать создание ордера методами MVC
        }
    }
}
