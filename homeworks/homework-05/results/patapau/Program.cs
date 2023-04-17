using System;
using System.IO.Pipes;
using patapau.Task1;
using patapau.Task2;

namespace patapau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK1");
            //Task 1
            Car car = new Car("1987","323","Mazda",50);
            Truck truck = new Truck("2020","alpha","Lancia",250);
            Motorcycle motorcycle = new Motorcycle("2018", "Street", "BMW", 20);            
            Vehicle[] vehicles = new Vehicle[] {car, truck, motorcycle};
            foreach(var vehicle in vehicles)
            {
                //Проверим текущую скорость
                vehicle.GetCurrentSpeed();
                //Проверим количество топлива
                vehicle.GetFuelLevel();
                //Зальем пол бака
                vehicle.HalfTank();
            }
            Console.WriteLine("TASK2");
            //Task 2 
            //Создаем клиентов банка
            PhysicalСlients physicalСlients = new PhysicalСlients("Patapau");
            physicalСlients.GetBankAccount();
            LegalСlients legalСlients = new LegalСlients("БГУ");
            legalСlients.GetBankAccount();
            //Выполним банковские операции
            IOperations[] operations = new IOperations[] { physicalСlients, legalСlients };
            foreach(var operation in operations)
            {
                operation.CheckBalance();
                operation.Deposit(100);
                operation.Withdrawal(50);
            }
        }
    }
}