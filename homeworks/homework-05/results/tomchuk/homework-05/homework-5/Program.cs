internal partial class Program
{
    private static void Main(string[] args)
    {
        Car car1 = new Car(2005, "BMW", "X5");
 
        Motorcycle motorcycle1 = new Motorcycle(2010, "MAISTO ", "20-11108");

        Truck truck1 = new Truck(1981, "Sod Buster", "MPC Models");


        Console.WriteLine(car1.Info());
        Console.WriteLine(motorcycle1.Info());
        Console.WriteLine(truck1.Info());
    }
}