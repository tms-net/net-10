// See https://aka.ms/new-console-template for more information
using ConsoleAppWithOOP;
using System.Xml.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        var motorcycle = new Motorcycle("Honda", "Rx-21", 2017);
        var car = new Car("BMW", "X4", 2005);
        var truck = new Truck("KamAZ", "53501", 1985);

        Console.WriteLine("We're going to try use 3 type of transport:");
        Console.WriteLine($"Motorcycle: {motorcycle.Make}-{motorcycle.Model} ({motorcycle.Year.ToString()});\nCar: {car.Make}-{car.Model} ({car.Year.ToString()});\nTruck: {truck.Make}-{truck.Model} ({truck.Year.ToString()}).");

        Console.WriteLine($"\nTry to start {motorcycle.Make}-{motorcycle.Model} engine");
        while (!motorcycle.succesStart())
        {
            Console.WriteLine("\nFailed");
        }
        Console.WriteLine($"\n{motorcycle.Make}-{motorcycle.Model} start moving!");
        motorcycle.Start();

        Console.WriteLine($"\nTry to start {car.Make}-{car.Model} engine");
        while (!car.succesStart())
        {
            Console.WriteLine("\nFailed");
        }
        Console.WriteLine($"\n{car.Make}-{car.Model} start moving!");
        car.Start();

        Console.WriteLine($"\nTry to start {truck.Make}-{truck.Model} engine");
        while (!truck.succesStart())
        {
            Console.WriteLine("\nFailed");
        }
        Console.WriteLine($"\n{truck.Make}-{truck.Model} start moving!");
        truck.Start();

        Console.WriteLine("\nLet's check ours vehicle's speed:");
        Console.WriteLine($"\n{motorcycle.Make}-{motorcycle.Model}: {motorcycle.CheckCurrentSpeed().ToString()};\n{car.Make}-{car.Model}: {car.CheckCurrentSpeed().ToString()};\n{truck.Make}-{truck.Model}: {truck.CheckCurrentSpeed().ToString()}.");
        
        Console.WriteLine("\nWe have done what we have wanted, It's time to stop!");

        if (motorcycle.succesStop())
        {
            motorcycle.Stop();
            Console.WriteLine($"\n{motorcycle.Make}-{motorcycle.Model} was successfully stopped");
        }
        else
        {
            Console.WriteLine($"\nOh no, there's accident with {motorcycle.Make}-{motorcycle.Model}!");
        }

        if (car.succesStop())
        {
            car.Stop();
            Console.WriteLine($"\nh {car.Make}-{car.Model} was successfully stopped");
        }
        else
        {
            Console.WriteLine($"\nOh no, there's accident with {car.Make}-{car.Model}!");
        }

        if (truck.succesStop())
        {
            truck.Stop();
            Console.WriteLine($"\nh {truck.Make}-{truck.Model} was successfully stopped");
        }
        else
        {
            Console.WriteLine($"\nOh no, there's accident with {truck.Make}-{truck.Model}!");
        }

        Console.ReadLine();
    }
}