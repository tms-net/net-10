using System.ComponentModel.Design;

double a;
double b;
double result;
char operations;

Console.WriteLine("Ведите первое число");
a = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Ведите опервтор");
operations = Convert.ToChar(Console.ReadLine());

Console.WriteLine("Ведите второе чисто");
b = Convert.ToDouble(Console.ReadLine());

if (operations == '+')
{
    result = a + b;
    Console.WriteLine(a + b = result);
}
else if (operations == '-') ;}
{
    Console.WriteLine(a - b = result); }

else if (operations == '*') ;
{ Console.WriteLine(a * b = result); }

else if (operations == '/') ;
{ Console.WtiteLine(a / b = result); }




