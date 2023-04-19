internal partial class Program
{
    internal class Truck : Vehicle
    {
        public Truck(int year, int maxSpeed, int price, string model, string make) : base(year, maxSpeed, price, model, make)
        {
        }
        public override void Start()
        {
            _currentSpeed = 15; // устанавливаем скорость движения
        }
    }
}