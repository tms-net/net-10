using ConsoleAppForBankoOperatons;
using ConsoleAppForBankoOperatons.Accounts;

internal class Program
{
    private static void Main(string[] args)
    {
        PersonalBankAccount persona = new PersonalBankAccount("8-800-555-35-35", "Back Inc.", "Persona", "Personal address", "01234567891014", 1000);
        EntityBankAccount envy = new EntityBankAccount("8-800-555-35-35", "Back Inc.", "Emvy Inc.", "Envy", "Envy address", "123456789", 1000000);
        persona.ActivateAccount(); envy.ActivateAccount();
        Console.WriteLine($"Personal account:\n{persona}\n\nEnvy account: \n{envy}");


        List<Сurrency>? currencies = new List<Сurrency>();
        currencies.Add(new Сurrency("USD", "840"));
        currencies.Add(new Сurrency("BYN", "933"));
        currencies.Add(new Сurrency("EUR", "978"));

        List<СurrencyConverter>? converter = new List<СurrencyConverter>();
        converter.Add(new СurrencyConverter("840", 2.8287, DateTime.Parse("5/10/2023 00:00:00"), DateTime.Parse("5/10/2023 23:59:59")));
        converter.Add(new СurrencyConverter("840", 2.8354, DateTime.Parse("5/11/2023 00:00:00"), DateTime.Parse("5/11/2023 23:59:59")));
        converter.Add(new СurrencyConverter("840", 2.7997, DateTime.Parse("5/12/2023 00:00:00")));
        converter.Add(new СurrencyConverter("978", 3.1189, DateTime.Parse("5/10/2023 00:00:00"), DateTime.Parse("5/10/2023 23:59:59")));
        converter.Add(new СurrencyConverter("978", 3.1070, DateTime.Parse("5/11/2023 00:00:00"), DateTime.Parse("5/11/2023 23:59:59")));
        converter.Add(new СurrencyConverter("978", 3.0595, DateTime.Parse("5/12/2023 00:00:00")));

        persona.AddOverdrive(1000);
        Console.WriteLine($"\nUpdated personal account:\n{persona}");
        Console.ReadLine();
        Console.Clear();

        Tranceaction traceacrion1 = new Tranceaction("2010", 500, "840");
        Console.WriteLine(traceacrion1.DoTranceaction(persona, envy, converter));
        Console.WriteLine($"Personal account:\n{persona}\n\nEnvy account: \n{envy}");

        Console.ReadLine();
        Console.Clear();
        Tranceaction traceacrion2 = new Tranceaction("1010", 50, "978");
        Console.WriteLine(traceacrion2.DoTranceaction(envy, persona, converter));
        persona.TakeOffOverdrive();
        Console.WriteLine($"Personal account:\n{persona}\n\nEnvy account: \n{envy}");




        Console.ReadLine();
    }    
}