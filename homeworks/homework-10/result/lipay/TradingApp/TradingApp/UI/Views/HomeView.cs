using TradingApp.UI.Models;

namespace TradingApp.UI.Views
{
    public class HomeView : BaseView<HomeModel>
    {
        public HomeView(UIController controller) : base(controller)
        {
        }

        internal override void Show()
        {
            Console.Clear();
            Console.WriteLine($" Данные {Model.SymbolData.SymbolName}:");
            Console.WriteLine($" Текущая цена: {Model.SymbolData.Data.Last().Value}");
            Console.WriteLine($" Капитализация: {Model.SymbolData.MarketCap}");
            Console.WriteLine($" Баланс: {Model.AccountBalance}");

            // Опции для создания ордера
            Console.WriteLine("Опции:");
            Console.WriteLine(" 1. Изменить гранулярность");
            Console.WriteLine(" 2. Изменить период");
            Console.WriteLine(" 3. Создать ордер");

            var option = ViewHelper.GetNumberFromConsole(1, 2, 3);
            switch (option)
            {
                case 1:
                    var granularity = ViewHelper.GetGranularityFromConsole();
                    Controller.Home(Model.SymbolData.SymbolName, Model.SymbolData.CurrentPeriod().Value, granularity);
                    break;

                case 2:
                    var period = ViewHelper.GetTimeSpanFromConsole();
                    Controller.Home(Model.SymbolData.SymbolName, period, Model.SymbolData.CurrentGranularity().Value);
                    break;

                case 3:
                    Controller.Order(Model.SymbolData.SymbolName);
                    break;
            }
        }
    }
}
