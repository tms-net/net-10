using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_lesson5_hw
{

    internal class Program
    {
        public interface IMove
        {
            void Start();
            void Stop();
        }
        internal abstract class Vehicle : IMove
        {
            protected int _currentSpeed;
            protected Vehicle(int year, double engineCapacity, string model, string make)
            {
                Year = year;
                EngineCapacity = engineCapacity;
                Model = model;
                Make = make;
            }
            int Year { get; } // Год выпуска
            double EngineCapacity { get; } // Объем двигателя
            string Model { get; } // Модель
            string Make { get; }// Производитель
            public abstract void Start();

            public virtual void VehicleInformation()
              { 
                Console.WriteLine($" Vehicle: {Make} {Model}, Engine Capacity: {EngineCapacity}, Year {Year} ");
              } 
            

            public virtual void Stop()
            {
                _currentSpeed = 0;
            }
            internal class Car : Vehicle
            {
                public Car(int year, double engineCapacity, string model, string make) : base(year, engineCapacity, model, make) { }
                public override void Start()
                {
                    _currentSpeed = 10;
                }
            }
            internal class Truck: Vehicle
            {
                public Truck(int year, double engineCapacity, string model, string make) : base(year, engineCapacity, model, make) { }
                public override void Start()
                {
                    _currentSpeed = 5;
                }
            }
            internal class Motorcycle: Vehicle
            {
                public Motorcycle(int year, double engineCapacity, string model, string make) : base(year, engineCapacity, model, make) { }
                private bool _tripodEjected;
                public override void Start()
                {
                    _currentSpeed = 20;
                    _tripodEjected = false;
                }
                public override void Stop()
                {
                    base.Stop();
                    _tripodEjected = true;
                }
            }


            private static void Main(string[] args)
            {
                Car Skoda = new Car(2009, 1.4, "Octavia", "Skoda");
                Car BMW = new Car(2013, 4.0, "e92", "BMW");
                Car Rolls_Royce = new Car(2022, 6.8, "Ghost", "Rolls Royce");

                Motorcycle Suzuki = new Motorcycle(2005, 1.8, "Boulevard M109R", "Suzuki");
                Motorcycle Indian = new Motorcycle(2015, 1.1, "Scout", "Indian");

                Truck MAZ = new Truck(2017, 11.5, "5551", "MAZ");

                Console.WriteLine("Select class");
                Console.WriteLine("1 - Car, '2' - Motorcycle, '3' - Truck ");
                string choise = Console.ReadLine();
                            
                {
                    switch (choise)
                    {
                        case "1":
                            {
                                Console.WriteLine("Choose the vehicle");
                                Console.WriteLine("1 - Skoda Octavia, 2 - BMW e92, 3 - Rolls Royce");
                                string choise1 = Console.ReadLine();
                                switch (choise1)
                                {
                                    case "1":
                                        Skoda.VehicleInformation();
                                        break;
                                    case "2":
                                        BMW.VehicleInformation();
                                        break;
                                    case "3":
                                        Rolls_Royce.VehicleInformation();
                                        Console.WriteLine("The call to the tax office is processing...");
                                        break; 
                                    default: 
                                        Console.WriteLine("Invalid value");
                                        break;
                                }
                                break;
                            }
                        case "2": 
                            {
                                Console.WriteLine("Choose the vehicle");
                                Console.WriteLine("1 - Suzuki, 2 - Indian");
                                string choise2 = Console.ReadLine();
                                switch (choise2)
                                {
                                    case "1":
                                        Suzuki.VehicleInformation();
                                        break;
                                    case "2":
                                        Indian.VehicleInformation();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid value");
                                        break;
                                        
                                }break;
                            }
                        case "3":
                            {
                                Console.WriteLine("your fate is sealed ");
                                MAZ.VehicleInformation();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid value");
                                break;
                            }
                    }
                }
            }   
        }
    }
}
