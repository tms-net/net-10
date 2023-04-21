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
            Car car = new Car("1987", "323", "Mazda", 50);
            Truck truck = new Truck("2020", "alpha", "Lancia", 250);
            Motorcycle motorcycle = new Motorcycle("2018", "Street", "BMW", 20);
            Vehicle[] vehicles = new Vehicle[] { car, truck, motorcycle };
            foreach (var vehicle in vehicles)
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
            Console.WriteLine("-----------------------------------------------------------");
            //Создаем клиентов банка
            PhysicalСlients physicalСlients = new PhysicalСlients("Patapau");
            physicalСlients.GetBankAccount();
            LegalСlients legalСlients = new LegalСlients("БГУ");
            legalСlients.GetBankAccount();

            //Выполним банковские операции(Зачислим всем клиентам 100 рублей)
            IOperations[] operations = new IOperations[] { physicalСlients, legalСlients };
            foreach (var operation in operations)
            {
                operation.Deposit(100);
            }

            //Выполним перевод денег между клиентами
            legalСlients.Transfer(physicalСlients, 50);
            physicalСlients.Transfer(legalСlients, 20);
            Console.WriteLine(physicalСlients.GetOperationStatus());
            //Сделаем депозиты
            physicalСlients.Deposit(100);
            physicalСlients.Deposit(100);


            //Загрузим весь журнал логов и просмотрим      только на Пополнение
            var logs = physicalСlients.GetHistoryLog();
            foreach (var log in logs/*.Where(x => x.Category == "Пополнение")*/)
            {
                Console.WriteLine($"{log.GetLog()}");
            }
            Console.WriteLine(physicalСlients.CheckBalance());
            Console.WriteLine(physicalСlients.GetBankAccount());



        }

    }
}