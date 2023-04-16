// See https://aka.ms/new-console-template for more information
using ConsoleAppWithOOP;
using System.Xml.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        var motorcycle = new Motorcycle(2017);
        motorcycle._tripodEjected = true;
    }
}