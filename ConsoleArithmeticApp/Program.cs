internal class Program
{
    private static void Main(string[] args)
    {
        //Realise next operations +, -, *, /, ^, %

        string firstNumberString = "";
        string secondNumberString = "";
        string mathOperatorString = "";
        string choice = "";

        double firstNumberDouble = 0.0;
        double secondNumberDouble = 0.0;
        double answer = 0.0;

        bool flagOfEnding = false;
        bool flagOfChosenOperator = false;
        bool flagOfFirstNumber = false;
        bool flagOfSecondNumber = false;

        while (!flagOfEnding)
        {
            Console.WriteLine("\nThis Console app can perform next arithmetic operations for two numbers: \n+ (Addition)\n- (Subtraction)\n* (Multiplication)\n/ (Division)\n^ (Raise a number to a specified power)\n% (Modulo)");

            while (!flagOfFirstNumber)
            {
                Console.WriteLine("\nInput first number:");
                try
                {
                    firstNumberString = Console.ReadLine();
                    if (double.TryParse(firstNumberString, out firstNumberDouble))
                    {
                        flagOfFirstNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Inputted text can't be converted into number");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Inputted text for first number isn't correct." + e);
                    firstNumberString = "";
                }
            }
            while (!flagOfChosenOperator)
            {
                try
                {
                    Console.WriteLine("\nInput math operator:");
                    mathOperatorString = Console.ReadLine();
                    if (mathOperatorString.Length == 1)
                    {
                        switch (mathOperatorString)
                        {
                            case "+":
                                flagOfChosenOperator = true;
                            break;
                            case "-":
                                flagOfChosenOperator = true;
                            break;
                            case "*":
                                flagOfChosenOperator = true;
                            break;
                            case "/":
                                flagOfChosenOperator = true;
                            break;
                            case "^":
                                flagOfChosenOperator = true;
                            break;
                            case "%":
                                flagOfChosenOperator = true;
                            break;
                            default:
                                Console.WriteLine("Inputted text isn't an available math operator.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inputted text can't be longer than one simbol.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Inputted text for math operator isn't correct." + e);
                    mathOperatorString = "";
                }
            }
            while (!flagOfSecondNumber)
            {
                Console.WriteLine("\nInput second number:");
                try
                {
                    secondNumberString = Console.ReadLine();
                    if (double.TryParse(secondNumberString, out secondNumberDouble))
                    {
                        flagOfSecondNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Inputted text can't be converted into number");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Inputted text for second number isn't correct." + e);
                    secondNumberString = "";
                }
            }
            switch (mathOperatorString)
            {
                case "+":
                    answer = firstNumberDouble + secondNumberDouble;                   
                break;
                case "-":
                    answer = firstNumberDouble / secondNumberDouble;
                break;    
                case "*":
                    answer = firstNumberDouble * secondNumberDouble;
                break;
                case "/":
                    answer = firstNumberDouble / secondNumberDouble;
                break;
                case "^":
                    answer = Math.Pow(firstNumberDouble, secondNumberDouble);
                break;
                case "%":
                    answer = firstNumberDouble % secondNumberDouble;
                break;
            }
            Console.WriteLine($"\n{firstNumberDouble} {mathOperatorString} {secondNumberDouble} = {answer}");

            Console.WriteLine("\nDo you want to use this answer for next operation? (y/n)");
            try
            {
                choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y": 
                        {
                            flagOfChosenOperator = false;
                            Console.WriteLine("\nDo you want to use this answer as a first or as a second number? (f/s)");
                            try
                            {
                                choice = Console.ReadLine();
                                switch (choice.ToLower())
                                {
                                    case "f":
                                    case "first":
                                    case "1":
                                        {
                                            firstNumberDouble = answer;
                                            flagOfFirstNumber = true;
                                            flagOfSecondNumber = false;
                                        }
                                        break;
                                    case "s":
                                    case "second":
                                    case "2":
                                        {
                                            secondNumberDouble = answer;
                                            flagOfSecondNumber = true;
                                            flagOfFirstNumber = false;  
                                        }
                                        break;
                                    default: 
                                        {
                                            Console.WriteLine("Incorrect input");
                                            flagOfEnding = true;
                                        }
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Inputted choice isn't correct." + e);
                                choice = "";
                                flagOfEnding = true;
                            }
                        }
                            break;
                    case "n": 
                        flagOfEnding = true;
                        break;
                    default:
                        {
                            Console.WriteLine("Incorrect input");
                            flagOfEnding = true;
                        } 
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Inputted choice isn't correct." + e);
                choice = "";
                flagOfEnding = true;
            }
            if (flagOfEnding)  
            { 
                Console.WriteLine("Program will be stopped."); 
            }            
        }
        Console.ReadLine();
    }
}