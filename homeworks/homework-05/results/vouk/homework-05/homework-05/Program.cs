using homework_05.vehicles;

namespace homeworks.homework_05.results.vouk.homework_05.homework_05
{
    internal class Program
    {
        static void Main()
        {
            // Create different vehicle models
            var ducatiStreetfighter = new Motorcycle("Ducati", "Streetfighter V4", "2023", 208, 250);
            var porscheTurbo = new Car("porsche", "911 Turbo", "2022", 640, 280, 2);
            var freightliner = new Truck("Freightliner", "FLA 9664", "1984", 500, 120, 8);

            // Write description of all vehicles
            Console.WriteLine(ducatiStreetfighter);
            Console.WriteLine(porscheTurbo);
            Console.WriteLine(freightliner);

            // Turn On engine of bike
            ducatiStreetfighter.StartEngine();
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());

            // Turn Off engine of bike
            ducatiStreetfighter.StopEngine();
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());

            // Turn On engine of bike
            ducatiStreetfighter.StartEngine();
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());

            // Increase speed of bike
            ducatiStreetfighter.IncreaseSpeed(10);
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());

            // Increase speed of bike on value bigger, than maximal and check, that its become not bigger than maximal
            ducatiStreetfighter.IncreaseSpeed(ducatiStreetfighter.MaxSpeed * 2);
            Console.WriteLine(ducatiStreetfighter.GetCurrentStateOfVehicle());

            // Turn On engine of Porsche and reach top speed
            porscheTurbo.StartEngine();
            porscheTurbo.IncreaseSpeed(porscheTurbo.MaxSpeed);
            Console.WriteLine(porscheTurbo.GetCurrentStateOfVehicle());

            // Decrease speed of Porsche and check that it not less than 0
            porscheTurbo.DecreaseSpeed(porscheTurbo.MaxSpeed * 2);
            Console.WriteLine(porscheTurbo.GetCurrentStateOfVehicle());

            // Check that it impossible to increase speed of Truck with turned off engine
            freightliner.StopEngine();
            freightliner.IncreaseSpeed(freightliner.MaxSpeed);
            Console.WriteLine(freightliner.GetCurrentStateOfVehicle());
        }
    }
}