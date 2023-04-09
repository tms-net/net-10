using System;

class Programm // Без класса у меня 4 раза вылетела консоль и Вижла вместе с ней
{
    static void Main()
    {
        var a = 5;
        var b = 10;

        // Сложение
        var sum = a + b;
        Console.WriteLine($"Сумма: {sum}");

        // Вычитание
        var difference = a - b;
        Console.WriteLine($"Разность: {difference}");

        // Умножение
        var product = a * b;
        Console.WriteLine($"Произведение: {product}");

        // Деление
        var quotient = a / b;
        Console.WriteLine($"Частное: {quotient}");

        // Возведение в степень
        var power = Math.Pow(a, b);
        Console.WriteLine($"Степень: {power}");

        Console.ReadKey();
    }

}