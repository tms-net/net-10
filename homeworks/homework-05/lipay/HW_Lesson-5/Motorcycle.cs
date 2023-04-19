internal partial class Program
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(int year, int maxSpeed, int price, string model, string make) : base(year, maxSpeed, price, model, make)
        {
        }
        private bool _tripodEjected;
        public override void Start()
        {
            _currentSpeed = 25; // устанавливаем скорость движения
            _tripodEjected = false;
        }
        public override void Stop()
        {
            base.Stop(); // сбрасываем скорость движения
            _tripodEjected = true;
        }
        public override void State()
        {
            PrintInfoLittle();
            Console.WriteLine($"Скорость: {_currentSpeed}, Подножка выставлена: {_tripodEjected}");
            Console.WriteLine("Вы проехали 1 час");
            if (CurrentRoadLengs < 0)
            {
                Console.WriteLine("Вы проехали весь путь! Поздравляем!");
            }
            else
            {
                Console.WriteLine($"Остаток пути: {CurrentRoadLengs -= _currentSpeed}");
            }
        }
    }
}