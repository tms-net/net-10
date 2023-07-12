namespace TradingApp.Patterns
{
    public class Program
    {
        public void Main()
        {
            var c1 = new Component1();
            var c2 = new Component2(c1);
            var c3 = new Component();

            var facade = new Facade(c1, c2, c3);
            facade.DoMagic();
        }
    }

    internal class IFacade
    {
        void DoMagic();
    }

    public class Facade : IFacade
    {
        public void DoMagic()
        {
            c1.SaveRecord();
            //  немного логики

            c2.DoSomeWork();

            c3.MakePayment();
        }
    }

    interface IService1
    {
        void MakePayment();
    }

    interface IService2
    {
        void SaveRecord();
    }


    public class Component2 : IService2
    {
        public Component2(IService1 service)
        {

        }

        public void DoSomeWork()
        {

        }
    }

    public class Component1
    {
        public DoSome Work()
        {

        }
    }
}
