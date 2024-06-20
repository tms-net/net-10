Console.WriteLine("Введите первое число: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите второе число: ");
int b = Convert.ToInt32(Console.ReadLine());

//Cумма
int sum = a + b;
Console.WriteLine($"Cумма = {sum}");

//Разность 
int sub = a - b;
Console.WriteLine($"Разность = {sub}");

//Умножение
int mul = a * b;
Console.WriteLine($"Умножение = {mul}");

//Деление 
int mod = a / b;
Console.WriteLine($"Деление = {mod}");

//Деление(дробное)
double mod1 = (double)a / b;
Console.WriteLine($"Деление(дробное) = {mod1}");

//Остаток от деления
int mod2 = a % b;
Console.WriteLine($"Остаток от деления = {mod2}");

//Возведение в степень (c помощью цикла вариант1)
int num = 1;
for (int i = 0; i < b; i++)
{
    num = num * a;
}
Console.WriteLine($"Возведение в степень с помощью цикла (Вар1) = {num}");

//Возведение в степень вариант 2(не сработало с отрицательной степенью)
/*int num1 = 1;
int pow = Math.Abs(b);
var result = 1 /num1;
for (int i = 0; i < pow;i++)
{ 
    result = num1 * a; 
}
if (b < 0)
{
    result = 1 / num1;
}
Console.WriteLine($"Возведение в степень с помощью цикла (Вар2) = {result}");
*/


//Возведение в степень вариант 3
Console.WriteLine($"{a} ^ {b} = {Math.Pow(a, b)}");

