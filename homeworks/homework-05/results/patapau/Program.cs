using System;
using patapau.Task1;

namespace patapau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Car car = new Car("1987","323","Mazda",50);
            Truck truck = new Truck("2020","alpha","Lancia",250);
            Motorcycle motorcycle = new Motorcycle("2018", "Street", "BMW", 20);
            IFuelable[] fuelables = new IFuelable[] {car, truck, motorcycle};
            foreach(var fuelable in fuelables)
            {
                fuelable.HalfTank();
            }
            //Task 2
        }
    }
}