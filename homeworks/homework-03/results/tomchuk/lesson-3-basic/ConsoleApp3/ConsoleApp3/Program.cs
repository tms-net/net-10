Console.Write("Введите первое число: ");
double a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите второе число: ");
double b = Convert.ToInt32(Console.ReadLine());
bool flag = true;
while (flag)
{
    Console.Write("Введите операцию: '+', '-', '*', '/', '^', '%', ('0' - для выхода из программы): ");
    char operation = Convert.ToChar(Console.ReadLine());
    double result;
    switch (operation)
    {
        case '+':
            {
                result = a + b;
                Console.WriteLine($"{a} + {b} = {result}");
                break;
            }
        case '-':
            {

                result = a - b;
                Console.WriteLine($"{a} - {b} = {result}");
                break;
            }
        case '*':
            {
                result = a * b;
                Console.WriteLine($"{a} * {b} = {result}");
                break;
            }
        case '/':
            {
                result = a / b;
                Console.WriteLine($"{a} / {b} = {result}");
                break;
            }
        case '^':
            {
                result = Math.Pow(a, b);
                Console.WriteLine($"{a} ^ {b} = {result}");
                break;
            }
        case '%':
            {
                result = a % b;
                Console.WriteLine($"{a} % {b} = {result}");
                break;
            }
        case '0':
            {
                flag = false;
                Console.WriteLine("Выполнение программы завершено");
                break;
            }
        default:
            {
                Console.WriteLine("Неверный ввод");
                break;
            }

    }
}
