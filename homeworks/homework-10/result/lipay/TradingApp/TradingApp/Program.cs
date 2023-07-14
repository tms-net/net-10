using TradingApp;
using TradingApp.UI;

internal class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Имитация работы других трейдеров
        //  - создание ордеров
        //  - работа в разных потоках

        var tradingGenerator = new TradingGenerator();
        tradingGenerator.StartTradingDay();

        // Отображение
        //  - Экраны (Screen) ; Страница (Page) ; View
        //      - Home (Главный)
        //          - Текущие данные (символ, баланс, ...)
        //      - Опции отображения
        //      - Создание ордера

        Console.WriteLine("Hello, Trading Platform!");

        // Получить зависимости
        //  - ITradingDataRetreiver
        //  - ITradingLogic

        var random = new Random();
        var currentBalance = random.Next(1000, 100000);

        var tradingDataService = new TradingDataService();
        var tradingEngine = new TradingEngine();
        var accountManager = new AccountManager(currentBalance, tradingDataService, tradingEngine);

        var uiController = new UIController(tradingDataService, accountManager);

        uiController.Index();
    }
}