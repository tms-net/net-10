using hw_5.Vehicles;
using System.Net.Http.Headers;

namespace hw_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var aventador = new Car("2017", "Aventador", "Lamborghini", "300", 2);
            var boeing = new Plane("2017", "737 Max", "Boeing", "842", 5600);
            var sprotik = new Motorcycle("2023", "Sportster S", "Harley Davidson", "231");

            Console.WriteLine(sprotik);
            Console.WriteLine(boeing);
            Console.WriteLine(aventador);

            aventador.StartMovement(100);
            aventador.CheckState();
            aventador.StopMovement();
            aventador.CheckState();
            aventador.StopEngine();
            aventador.CheckState();

            boeing.StartEngine();
            boeing.CheckState();
            boeing.StartMovement(100);
            boeing.CheckState();
            boeing.StopEngine();
            boeing.CheckState();
        }
    }
}