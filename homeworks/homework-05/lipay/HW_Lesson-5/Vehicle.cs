internal partial class Program
{
    internal abstract class Vehicle : IMovable
    {
        protected int _currentSpeed;
        
        protected Vehicle(int year, int maxSpeed,int price, string model, string make)
        {
            Year = year;
            MaxSpeed = maxSpeed;
            Price = price;
            Model = model;
            Make = make;
        }
        string Make { get; } // Производитель
        string Model { get; } // Модель
        int Year { get; } // Год выпуска
        int MaxSpeed { get; } //Максимальная скорость
        int Price { get; } // Цена
        public abstract void Start();
        public virtual void Stop()
        {
            if (_currentSpeed > 0)
            {
                _currentSpeed -= 20;
            }
            else
            {
                _currentSpeed = 0;
            }
         
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Средство передвижения:{Model}, производитель:{Make}, Цена: {Price}, Максимальная скорость: {MaxSpeed}, Год выпуска: {Year}");
        }
        public virtual void PrintInfoLittle()
        {
            Console.WriteLine($"Средство передвижения:{Model}, производитель:{Make}, Максимальная скорость: {MaxSpeed}");
        }
        public virtual void State()
        {
            PrintInfoLittle();
            
            if (CurrentRoadLengs < 0)
            {
                Console.WriteLine("Вы проехали весь путь! Поздравляем!");
                Console.WriteLine($"Вы проехали путь за {CountHours} часов!");
                return;
            }
            else
            {
                Console.WriteLine($"Ваша Скорость: {_currentSpeed}");
                Console.WriteLine("Вы проехали 1 час");
                Console.WriteLine($"Остаток пути: {CurrentRoadLengs -= _currentSpeed}");
                CountHours++;
            }
            
        }
        int Roadlengs { get; set; }
        Random random = new Random();
        protected int CurrentRoadLengs;
        protected int CountHours;
        

        public void PrintRoadLengs()
        {
            Roadlengs = random.Next(100, 200);
            Console.WriteLine("Ваша трасса составляет: " + Roadlengs + " км.");
            CurrentRoadLengs = Roadlengs;
        }
        public int GetCurrentRoad()
        {
            return CurrentRoadLengs;
        }
        

    }
}