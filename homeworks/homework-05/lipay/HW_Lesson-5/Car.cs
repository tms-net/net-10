internal partial class Program
{
    internal class Car : Vehicle
    {
        public Car(int year, int maxSpeed, int price, string model, string make) : base(year, maxSpeed, price, model, make)
        {
        }
        public override void Start()
        {
            _currentSpeed += 20; // устанавливаем скорость движения
        }
    }
}