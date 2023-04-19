internal partial class Program
{
    internal class Car : Vehicle
    {
        int _currentSpeed;

        public override void Start()
        {
            _currentSpeed = 10; // устанавливаем скорость движения
        }

        public override void Stop()
        {
            _currentSpeed = 0; // сбрасываем скорость движения
        }
    }
}
