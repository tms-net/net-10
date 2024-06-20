// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;
using System.Text.Json;

Console.WriteLine("Hello, World!");


JsonSerializer.Serialize<Employee>(new Employee(), new JsonSerializerOptions
{
    AllowTrailingCommas = true,
    // Converters = new[] { typeof(Employee) } // IJsonCoverter
    // Encoder
});


Employee ivan = new()
{
    Name = "Ivan"
};

Employee petr = new()
{
    Name = "Petr"
};

Employee john = new()
{
    Name = "John"
};



//ivan.DirectReports = new List<Employee> { petr };

petr.Manager = john;
ivan.Manager = john;

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.Preserve,
    WriteIndented = true
};

var dep = new Department
{
    Employees = new List<Employee> { ivan, petr, john }
};


var jsonNewtonsoft = Newtonsoft.Json.JsonConvert.SerializeObject(dep);

var jsonNewtonsoftRef = Newtonsoft.Json.JsonConvert.SerializeObject(dep,
    new Newtonsoft.Json.JsonSerializerSettings { 
        PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All
    });

string refJson = JsonSerializer.Serialize(dep, options);

string json = JsonSerializer.Serialize(dep);

Console.WriteLine($"Ref serialized:\n{refJson}");

Console.WriteLine($"Standard serialized:\n{json}");

Department tylerDeserialized =
    JsonSerializer.Deserialize<Department>(refJson, options);

tylerDeserialized =
    JsonSerializer.Deserialize<Department>(json);

Console.ReadLine();


public class Employee
{
    public string? Name { get; set; }
    public Employee? Manager { get; set; }
    public List<Employee>? DirectReports { get; set; }
}

public class Department
{
    public List<Employee> Employees { get; set; }
}

// 1:(Employee, Ivan) ->   2:(Employee, Manager)   <-  3:(Employee, Petr)

// 
