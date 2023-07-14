using static Program;

namespace TradingApp.UI.Views
{
    internal class IndexView : BaseView
    {
        public IndexView(UIController controller) : base(controller)
        {
        }

        internal override void Show()
        {
            var symbol = ViewHelper.GetSymbolFromConsole("Input Symbol name:");

            Console.WriteLine("For retrieving info need period");

            var period = ViewHelper.GetTimeSpanFromConsole();

            var granularity = ViewHelper.GetGranularityFromConsole();

            Controller.Home(symbol, period, granularity);
        }

        
    }
}
