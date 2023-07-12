namespace TradingApp.Patterns
{
    public interface IAlternativeCurrentConnector
    {
        int GetCurrent();
    }

    public interface IUsbConnector
    {
        int GetResistance();
    }

    // Inteface1 ---  Adapter   ---- Interface2

    public class AdapterUsbToAC : IAlternativeCurrentConnector
    {
        IUsbConnector _service2;

        public AdapterUsbToAC(IUsbConnector service2)
        {
            _service2 = service2;
        }

        public int GetCurrent()
        {
            return 100 * _service2.GetResistance();
        }
    }

    public class Component
    {
        IAlternativeCurrentConnector _service;

        public Component(IAlternativeCurrentConnector service)
        {
            _service = service;
        }
    }
}
