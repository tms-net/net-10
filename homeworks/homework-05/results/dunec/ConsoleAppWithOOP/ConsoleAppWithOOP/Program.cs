// See https://aka.ms/new-console-template for more information
using ConsoleAppWithOOP;
using ConsoleAppWithOOP.Vehicles;
using System.Reflection;
using System.Xml.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        var motorcycle = new Motorcycle(make: "Honda", model: "Rx21", 2017, 4.59);
        var car = new Car(make: "BMW", model: "X4", 2005, 10.36);
        var truck = new Truck(make: "KamAZ", model: "53501", 1985, 21.4);

        Console.WriteLine("We're going to try use 3 type of transport:");
        Console.WriteLine($"Motorcycle: {motorcycle.Make}-{motorcycle.Model} ({motorcycle.Year.ToString()});\nCar: {car.Make}-{car.Model} ({car.Year.ToString()});\nTruck: {truck.Make}-{truck.Model} ({truck.Year.ToString()}).");

        Console.WriteLine($"\nTry to start {motorcycle.Make}-{motorcycle.Model} engine");
        while (!motorcycle.SuccesStart()) 
        {
            Console.WriteLine("Failed");
        }
        motorcycle.Start();
        Console.WriteLine($"{motorcycle.Make}-{motorcycle.Model} start moving!");
        

        Console.WriteLine($"\nTry to start {car.Make}-{car.Model} engine");
        while (!car.SuccesStart())
        {
            Console.WriteLine("Failed");
        }
        car.Start();
        Console.WriteLine($"{car.Make}-{car.Model} start moving!");
        

        Console.WriteLine($"\nTry to start {truck.Make}-{truck.Model} engine");
        while (!truck.SuccesStart())
        {
            Console.WriteLine("Failed");
        }
        truck.Start();
        Console.WriteLine($"{truck.Make}-{truck.Model} start moving!");
        

        Console.WriteLine("\nLet's check ours vehicle's speed:");
        Console.WriteLine($"{motorcycle.Make}-{motorcycle.Model}: {motorcycle.GetCurrentSpeed().ToString()};\n{car.Make}-{car.Model}: {car.GetCurrentSpeed().ToString()};\n{truck.Make}-{truck.Model}: {truck.GetCurrentSpeed().ToString()}.");
        
        Console.WriteLine("\nWell, Now let's check: Could our vehicles stop on a 50 meter road?, It's time to stop!");

        Random ran = new Random();
        SetStatusOfRoad(ran.Next(1, 4), motorcycle);
        if (motorcycle.SuccessfulStopOnDistance(50))
        {
            Console.WriteLine($"{motorcycle.Make}-{motorcycle.Model} was successfully stopped");
        }
        else
        {
            Console.WriteLine($"Oh no, there's the accident with {motorcycle.Make}-{motorcycle.Model}!");
        }

        SetStatusOfRoad(ran.Next(1, 4), car);
        if (car.SuccessfulStopOnDistance(50))
        {
            Console.WriteLine($"{car.Make}-{car.Model} was successfully stopped");
        }
        else
        {
            Console.WriteLine($"Oh no, there's the accident with {car.Make}-{car.Model}!");
        }

        SetStatusOfRoad(ran.Next(1, 4), truck);
        if (truck.SuccessfulStopOnDistance(50))
        {
            Console.WriteLine($"{truck.Make}-{truck.Model} was successfully stopped");
        }
        else
        {
            Console.WriteLine($"Oh no, there's the accident with {truck.Make}-{truck.Model}!");
        }

        Console.ReadLine();
    }

    public static void SetStatusOfRoad(int indexOfStatus, Vehicle vehicle)
    { 
        switch (indexOfStatus)
        {
            case 1:
                {
                    Console.WriteLine($"\n{vehicle.Make}-{vehicle.Model} are moving on dry asphalt");
                    vehicle.CoefficientOfFriction = 0.8;                 
                }                
                break;
            case 2:
                {
                    Console.WriteLine($"\n{vehicle.Make}-{vehicle.Model} are moving on wet asphalt");
                    vehicle.CoefficientOfFriction = 0.4;
                }
                break;
            case 3:
                {
                    Console.WriteLine($"\n{vehicle.Make}-{vehicle.Model} are moving on ice");
                    vehicle.CoefficientOfFriction = 0.1;                    
                }
                break;
        }
    }
}