namespace Patterns
{
    internal class IoCProgramm
    {
        public void Main()
        {
            // Container.Register<ITradingDataRetreiver, TradingDataRetreiver>(LifeTime.Singleton)

            // TradingDataRetreiverFactory

            // Container.Register<ITradingDataRetreiver, TradingDataRetreiver>(() => new TradingDataRetreiver(), LifeTime.Singleton)

            // Container.Register<ITradingDataRetreiver, TradingDataRetreiver>(
            //  (ctx) => ctx.Resolve<TradingDataRetreiverFactory>().CreateRetriever(), LifeTime.Singleton)

            // Создание сущностей
            //  - Определение времени жизни
            //  - Внедрение зависимостей (Dependency Injection)

            // IoC/DI (Dependency Injection)

            // Container -> Control (создание, управлние сущностями), Injection

            // Interface == Service

            // Container.Resolve<ITradingLogic>()
            // -> dependencies
            //    - ITradingDataRetreiver
            //      - new TradingDataRetreiver()
            //    - IDealAccommodationService
            //      - new DealAccommodationService()

            // Container.Register<ITradingLogic, TradingLogic>()

        }
    }
}
