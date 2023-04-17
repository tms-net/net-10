using System;

abstract class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }

    public void Start()
    {
        Console.WriteLine("Запуск двигателя");
    }

    public void Stop()
    {
        Console.WriteLine("Остановка двигателя");
    }

    public abstract void Drive();
}

class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Едем по дороге на автомобиле");
    }
}

class Bicycle : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Катаемся на велосипеде");
    }
}

class Motorcycle : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Катаемся на мотоцикле");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Car();
        car.Make = "Нурлан точно";
        car.Model = "не Сабуров";
        car.Year = "2000";
        car.Start();
        car.Drive();
        car.Stop();

        Vehicle bicycle = new Bicycle();
        bicycle.Make = "Создатель";
        bicycle.Model = "Просто.... Модель";
        bicycle.Year = "2001";
        bicycle.Start();
        bicycle.Drive();
        bicycle.Stop();

        Vehicle motorcycle = new Motorcycle();
        motorcycle.Make = "Клоун";
        motorcycle.Model = "Без понятия";
        motorcycle.Year = "2002";
        motorcycle.Start();
        motorcycle.Drive();
        motorcycle.Stop();

        Console.ReadKey();
    }
}

