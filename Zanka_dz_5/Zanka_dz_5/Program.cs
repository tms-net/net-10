using Zanka_dz_5;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        car.Make = "Ваз";
        car.Model = "228";
        car.Year = 2013;
        car.Maxpeople = 6;
        car.MaxSpeed = 500;

        Truck truck = new Truck();
        truck.Make = "MAN";
        truck.Model = "MAN";
        truck.Year = 2020;
        truck.Maxpeople = 2;
        truck.MaxSpeed = 150;

        Motorcycle motorcycle = new Motorcycle();
        motorcycle.Make = "MAN";
        motorcycle.Model = "MAN";
        motorcycle.Year = 2020;
        motorcycle.Maxpeople = 2;
        motorcycle.MaxSpeed = 150;
    }
}

