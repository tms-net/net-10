// See https://aka.ms/new-console-template for more information
using EnititesLib;
using KlindyukHW8;
using System.Xml.Linq;


var sm = new StudentManager();
sm.AddStudent("Michael Jackson", 57, 'm', 3);
sm.AddStudent("Peter Parker", 23, 'm', 7);
sm.AddStudent("Harry Potter", 16, 'm', 10);

uint inputId;
string inputName;
byte inputAge;
char inputGender;
byte inputGrade;

void SetInputId()
{
    Console.Write("ID: ");
    inputId = Convert.ToUInt32(Console.ReadLine());
};
void SetInputParameters()
{
    Console.Write("Name: ");
    inputName = Console.ReadLine();
    Console.Write("Age: ");
    inputAge = Convert.ToByte(Console.ReadLine());
    Console.Write("Gender: ");
    inputGender = Convert.ToChar(Console.ReadLine());
    Console.Write("Grade: ");
    inputGrade = Convert.ToByte(Console.ReadLine());
};
bool launch = true;
var answer = () => Convert.ToUInt32(Console.ReadLine());
var possibleActions = () => Console.WriteLine("Choose your action:\n"
                  + "1 - Get Info All Students\n"
                  + "2 - Get Info By ID\n"
                  + "3 - Get Info By Name\n"
                  + "4 - Add New Student\n"
                  + "5 - Update Student By ID\n"
                  + "6 - Remove Student By ID\n"
                  + "7 - Cancel The Last Move\n"
                  + "8 - Exit\n");
try
{
    while (launch)
    {
        possibleActions();
        Console.Write("Your answer: ");
        var myChoose = answer();
        if (myChoose > 0 && myChoose < 9)
        {
            switch (myChoose)
            {
                case 1:
                    Console.WriteLine("\nGet Info About All Students");
                    Console.WriteLine(sm.GetAllStudentInfo());
                    break;
                case 2:
                    Console.WriteLine("Get Info By ID");
                    SetInputId();
                    Console.WriteLine("\n" + sm.GetInfoById(inputId) + "\n");
                    break;
                case 3:
                    Console.WriteLine("Get Info By Name");
                    Console.Write("Name: ");
                    inputName = Console.ReadLine();
                    Console.WriteLine("\n" + sm.GetInfoByName(inputName) + "\n");
                    break;
                case 4:
                    Console.WriteLine("Add New Student");
                    SetInputParameters();
                    Console.WriteLine(sm.AddStudent(inputName, inputAge, inputGender, inputGrade) + "\n");
                    break;
                case 5:
                    Console.WriteLine("Update Student By ID");
                    SetInputId();
                    if (sm.checkId(inputId))
                    {
                        SetInputParameters();
                        Console.WriteLine(sm.UpdateStudentInfo(inputId, inputName, inputAge, inputGender, inputGrade) + "\n");
                    }
                    else
                    {
                        Console.WriteLine("\n" + sm.GetInfoById(inputId) + "\n");
                    }
                    break;
                case 6:
                    Console.WriteLine("Remove Student By ID");
                    SetInputId();
                    Console.WriteLine(sm.RemoveStudent(inputId) + "\n");
                    break;
                case 7:
                    Console.WriteLine("Cancel The Last Move\n");
                    sm.LoadChanges();
                    break;
                case 8:
                    Console.WriteLine("Exit");
                    launch = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("You select a wrong value... Try again...\n");
        }
    }
}
catch (FormatException e)
{
    Console.WriteLine("\nYou select a wrong value... Try again...\n" + e.Message);
}
