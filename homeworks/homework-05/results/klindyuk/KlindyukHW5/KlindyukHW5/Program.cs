using KlindyukHW5.BankOpeartion.Entities;
using KlindyukHW5.Vehicle.Entities;

Motorcycle moto1 = new(1998, "Japan", "Suzuki");
Car car1 = new(2020, "German", "Porsche", "Sportcar");
Truck truck1 = new(2002, "Belarus", "MAZ", "Gasoline tanker", 2000);

Console.WriteLine(moto1.ToString());
Console.WriteLine(truck1.ToString());
Console.WriteLine(car1.ToString());
Console.WriteLine();

//------------------------------------------

Bank bank = new(10);
var transf = bank.Transfer(bank.clients[0].ClientId, bank.prClients[0].ClientId, 100);
Console.WriteLine(bank.GetInformation());
Console.WriteLine(transf);




