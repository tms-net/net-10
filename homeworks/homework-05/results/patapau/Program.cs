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
            var random = new Random();
            Car car = new Car("1987", "323", "Mazda", 50, Math.Floor(random.NextDouble() * 50));
            Truck truck = new Truck("2020", "alpha", "Lancia", 250, Math.Floor(random.NextDouble() * 250));
            Motorcycle motorcycle = new Motorcycle("2018", "Street", "BMW", 20, Math.Floor(random.NextDouble() * 20));
            Console.WriteLine($"Текущий уровень топлива равен {car.GetCurrentFuelLevel()}");
            try
            {
                car.RefuelHalfTank();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(car.GetLastRefuelInfo());






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
            try
            {
                legalСlients.Transfer(physicalСlients, 50);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            ////Загрузим весь журнал логов и просмотрим только на Пополнение
            var logs = legalСlients.GetHistoryLogs();
            foreach (var log in logs/*.Where(x=>x.Category == "Пополнение")*/)
            {
                Console.WriteLine($"{log.GetLog()}");
            }





            Console.WriteLine(physicalСlients.CheckBalance());
            Console.WriteLine(physicalСlients.GetBankAccount());
        }

    }


}