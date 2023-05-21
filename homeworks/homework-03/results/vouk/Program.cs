#region Variables

const string startMessage = "Welcome to simple arithmetic calculator!\n" +
                                     "Type number, press enter, then type arithmetic operation (+, -, *, /, ^), \n" +
                                     "again press enter and again type number with enter to calculate operation.\n" +
                                     "Type \"matrix\" to type first matrix, and when when the first matrix is entered, type * to start typing second matrix.\n" +
                                     "When the second matrix is entered, type = to see the result. Type \"arithmetic\" to back to the Arithmetic calculator\n" +
                                     "Type \"quit\" to close the program";
const string quitParameter = "quit";
const string wrongArithmeticSymbolError = "Wrong  arithmetic symbol, enter data again.";
const string zeroDivisionError = "Division by zero error.";
const string wrongType = "Parameter should be a type of number! Try again.";
const string inputOperatorMessage = "Please, input arithmetic operator: ";
const string inputFirstVariableMessage = "Please, input first variable: ";
const string inputSecondVariableMessage = "Please, input second variable: ";
string inputtedMenuParameter;

#endregion

Console.WriteLine(startMessage);
StartArithmeticCalculator();

void StartArithmeticCalculator()
{
    do
    {
        var firstVariable = GetDoubleVariableFromConsole(true, out var isNeedToExitCalculator);
        if (isNeedToExitCalculator) break;

        var operatorFromConsole = GetOperatorFromConsole(out isNeedToExitCalculator);
        if (isNeedToExitCalculator) break;

        var secondVariable = GetDoubleVariableFromConsole(false, out isNeedToExitCalculator);
        if (isNeedToExitCalculator) break;

        double result = default;

        switch (operatorFromConsole)
        {
            case "+":
                result = firstVariable + secondVariable;
                break;
            case "-":
                result = firstVariable - secondVariable;
                break;
            case "*":
                result = firstVariable * secondVariable;
                break;
            case "^":
                result = Math.Pow(firstVariable, secondVariable);
                break;
            case "/":
                if (secondVariable == 0)
                {
                    Console.WriteLine(zeroDivisionError);
                }
                else
                {
                    result = firstVariable / secondVariable;
                }
                break;
        }

        Console.WriteLine($"{firstVariable} {operatorFromConsole} {secondVariable} = {result}");
    } while (true);
}

double GetDoubleVariableFromConsole(bool isFirstVariable, out bool isNeedQuit)
{
    double result = default;

    do
    {
        if (isFirstVariable)
        {
            Console.WriteLine(inputFirstVariableMessage);
        }
        else
        {
            Console.WriteLine(inputSecondVariableMessage);
        }

        var currentInputtedParameter = Console.ReadLine();

        if (IsNeedToExitFromCalculator(currentInputtedParameter))
        {
            isNeedQuit = true;

            break;
        }

        isNeedQuit = false;
        var isInputtedValueCorrect = double.TryParse(currentInputtedParameter, out result);

        if (!isInputtedValueCorrect)
        {
            Console.WriteLine(wrongType);

            continue;
        }

        break;
    } while (true);


    return result;
}

string GetOperatorFromConsole(out bool isNeedQuit)
{
    string result = default;

    do
    {
        Console.WriteLine(inputOperatorMessage);
        var inputtedParameter = Console.ReadLine();

        if (IsNeedToExitFromCalculator(inputtedParameter))
        {
            isNeedQuit = true;

            break;
        }

        isNeedQuit = false;

        if (!inputtedParameter.Equals("+") & !inputtedParameter.Equals("-") & !inputtedParameter.Equals("*") & !inputtedParameter.Equals("^")
            & !inputtedParameter.Equals("/"))
        {
            Console.WriteLine(wrongArithmeticSymbolError);

            continue;
        }

        result = inputtedParameter;

        break;
    } while (true);

    return result;
}

bool IsNeedToExitFromCalculator(string inputtedParameter) => inputtedParameter.Equals(quitParameter);