using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zhdanov_hw5;

namespace Zhdanov_lesson5_hw
{

    internal class Program
    {
      
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

                                }
                                break;
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
