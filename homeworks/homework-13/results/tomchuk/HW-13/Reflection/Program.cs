using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        //Assembly a = Assembly.LoadFrom("MyExe.exe");
        Assembly a = Assembly.GetExecutingAssembly();

        // Gets the type names from the assembly.
        Type[] types = a.GetTypes();


        Console.WriteLine("Listing all types of the {0} assembly", a);
        foreach (Type myType in types)
        {
            Console.WriteLine(myType.FullName);
        }

        Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();

        #region Members

        Type t = typeof(TestClass);
        Console.WriteLine("Listing all members of the {0} type", t);

        // Lists static fields first.
        FieldInfo[] fi = t.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Static Fields ---");
        PrintMembers(fi);

        // Static properties.
        PropertyInfo[] pi = t.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Static Properties ---");
        PrintMembers(pi);

        // Static events.
        EventInfo[] ei = t.GetEvents(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Static Events ---");
        PrintMembers(ei);

        // Static methods.
        MethodInfo[] mi = t.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Static Methods ---");
        PrintMembers(mi);

        // Constructors.
        ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Constructors ---");
        PrintMembers(ci);

        // Instance fields.
        fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Instance Fields ---");
        PrintMembers(fi);

        // Instance properites.
        pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Instance Properties ---");
        PrintMembers(pi);

        // Instance events.
        ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Instance Events ---");
        PrintMembers(ei);

        // Instance methods.
        mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Instance Methods ---");
        PrintMembers(mi);

        #endregion

        Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();

        #region Attributes

        Type jsonClassType = typeof(TestClass);
        Console.WriteLine("Listing all the attributes of the {0} type", jsonClassType);
        foreach (var attr in jsonClassType.GetCustomAttributes(true))
        {
            Console.WriteLine(attr);
        }
        pi = jsonClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Console.WriteLine("--- Property attributes ---");
        foreach (var p in pi)
        {
            var attrs = p.GetCustomAttributes().ToArray();
            if (attrs.Any())
            {
                Console.WriteLine(" {0}:", p.Name);
                foreach (var attr in attrs)
                {
                    Console.WriteLine("    " + attr.GetType());
                }
            }
        }

        #endregion

        Console.WriteLine("\nPress enter to continue...");
        Console.ReadLine();
    }

    static void PrintMembers(MemberInfo[] ms)
    {
        foreach (MemberInfo m in ms)
        {
            Console.WriteLine("{0}{1}", "  ", m);
        }
        Console.WriteLine();
    }
}

class SingleUseTestClass
{
    public string TestProperty1 { get; set; }
}

class TestClass
{
    private int testField1;
    private string testField2;
    private static string testField3;

    public string TestProperty1 { get; set; }

    public void Dump()
    {
        Console.WriteLine($"{nameof(TestProperty1)}: {TestProperty1}");
    }
}