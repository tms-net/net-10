using System.Reflection;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Car BMW = new Car(10, 230, 60000, "X6", "BMW");
        Car AlfaRomeo = new Car(5, 230, 80000, "Stelvio", "Alfa Romeo");
        Car Audi = new Car(2, 250, 74000, "А7", "Audi");

        Motorcycle BMWF = new Motorcycle(3, 300, 40000, "F 800 ST", "BMW");
        Motorcycle Yamaha = new Motorcycle(3, 310, 46000, "YZF-R1 2020", "Yamaha");

        Truck Volvo = new Truck(7, 130, 100000, "FH16", "Volvo");

    

        Console.WriteLine("Выберите свое средство передвижения:");
        Console.WriteLine("1 - BMW X6, 2 - Alfa Romeo Stelvio, 3 - Audi F7, 4 - BMW F 800 ST, 5 - Yamaha YZF-R1 2020, 6 - Volvo FH16");
        string option1 = Console.ReadLine();
        switch (option1)
        {
            case "1":
                BMW.PrintInfo();
                BMW.PrintRoadLengs();
                Console.WriteLine();
                Console.WriteLine("Введите 1 - для увеличения скорости на, 2 - для уменьшения скорости");

                while (BMW.GetCurrentRoad() >= -20)
                {
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            BMW.Start();
                            BMW.State();
                            break;
                        case "2":
                            BMW.Stop();
                            BMW.State();
                            break;
                        default:
                            Console.WriteLine("Ввели неправильное значение.");
                            break;
                    };
                }
                    break;
            case "2":
                AlfaRomeo.PrintInfo();
                AlfaRomeo.PrintRoadLengs();
                Console.WriteLine();
                Console.WriteLine("Введите 1 - для увеличения скорости на, 2 - для уменьшения скорости");

                while (AlfaRomeo.GetCurrentRoad() >= 0)
                {
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            AlfaRomeo.Start();
                            AlfaRomeo.State();
                            break;
                        case "2":
                            AlfaRomeo.Stop();
                            AlfaRomeo.State();
                            break;
                        default:
                            Console.WriteLine("Ввели неправильное значение.");
                            break;
                    };
                }
                break;
            case "3":
                Audi.PrintInfo();
                Audi.PrintRoadLengs();
                Console.WriteLine();
                Console.WriteLine("Введите 1 - для увеличения скорости на, 2 - для уменьшения скорости");

                while (Audi.GetCurrentRoad() >= 0)
                {
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            Audi.Start();
                            Audi.State();
                            break;
                        case "2":
                            Audi.Stop();
                            Audi.State();
                            break;
                        default:
                            Console.WriteLine("Ввели неправильное значение.");
                            break;
                    };
                }
                break;
            case "4":
                BMWF.PrintInfo();
                BMWF.PrintRoadLengs();
                Console.WriteLine();
                Console.WriteLine("Введите 1 - для увеличения скорости на, 2 - для уменьшения скорости");

                while (BMWF.GetCurrentRoad() >= 0)
                {
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            BMWF.Start();
                            BMWF.State();
                            break;
                        case "2":
                            BMWF.Stop();
                            BMWF.State();
                            break;
                        default:
                            Console.WriteLine("Ввели неправильное значение.");
                            break;
                    };
                }
                break;
            case "5":
                Yamaha.PrintInfo();
                Yamaha.PrintRoadLengs();
                Console.WriteLine();
                Console.WriteLine("Введите 1 - для увеличения скорости на, 2 - для уменьшения скорости");

                while (Yamaha.GetCurrentRoad() >= 0)
                {
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            Yamaha.Start();
                            Yamaha.State();
                            break;
                        case "2":
                            Yamaha.Stop();
                            Yamaha.State();
                            break;
                        default:
                            Console.WriteLine("Ввели неправильное значение.");
                            break;
                    };
                }
                break;
            case "6":
                Volvo.PrintInfo();
                Volvo.PrintRoadLengs();
                Console.WriteLine();
                Console.WriteLine("Введите 1 - для увеличения скорости на, 2 - для уменьшения скорости");

                while (Volvo.GetCurrentRoad() >= 0)
                {
                    string option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            Volvo.Start();
                            Volvo.State();
                            break;
                        case "2":
                            Volvo.Stop();
                            Volvo.State();
                            break;
                        default:
                            Console.WriteLine("Ввели неправильное значение.");
                            break;
                    };
                }
                break;
            default:
                Console.WriteLine("Ввели неправильное значение.");
                break;
        };

        
        }
        

}

    




    
