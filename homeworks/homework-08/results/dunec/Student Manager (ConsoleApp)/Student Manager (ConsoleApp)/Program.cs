using Student_Manager__ConsoleApp_;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        
        StudentManager studentManagers = new StudentManager ();
        Console.WriteLine(studentManagers.ToString());
        studentManagers.AddStudent("Oba", 69, "compensator"); 
        studentManagers.AddStudent("ABOBA", 49, "transformer");
        studentManagers.AddStudent("DONE", 78, "male");
        studentManagers.AddStudent("OVER", 13, "female");
        studentManagers.AddStudent("PavelNTD", 21, "student1");
        Console.WriteLine(studentManagers.ToString());
        Console.WriteLine("--------------------------------------------------------------------------------------");
        RandomSubject(studentManagers, "Oba");
        RandomSubject(studentManagers, "ABOBA");
        RandomSubject(studentManagers, "DONE");
        RandomSubject(studentManagers, "OVER");
        RandomSubject(studentManagers, "PavelNTD");
        Console.WriteLine(studentManagers.ToString());
        Console.WriteLine("--------------------------------------------------------------------------------------");
        studentManagers.UpdateStudentInfo(studentNameOrId: "PavelNTD", newStudentName: "DunecNTD", newAge: 21, newGender: "student2");
        studentManagers.UpdateStudentInfo(studentNameOrId: "Oba", newStudentName: "OBA", newGender: "Autobot");
        studentManagers.UpdateStudentInfo(studentNameOrId: "ABOBA", newStudentName: "ABoBA", newAge: 33);
        studentManagers.UpdateStudentInfo(studentNameOrId: "DONE", newAge: 88, newGender: "supermale");
        Console.WriteLine(studentManagers.ToString());
        Console.WriteLine("--------------------------------------------------------------------------------------");
        studentManagers.UpdateStudentInfo(studentNameOrId: "DunecNTD", newStudentName: "PavelNTD");
        studentManagers.UpdateStudentInfo(studentNameOrId: "OVER", newAge: 16);
        studentManagers.UpdateStudentInfo(studentNameOrId: "DONE", newGender: "male");
        Console.WriteLine(studentManagers.ToString());
        Console.WriteLine("--------------------------------------------------------------------------------------");
        studentManagers.RemoveStudent("PavelNTD");
        Console.WriteLine(studentManagers.ToString());
        studentManagers.RollBack();
        Console.WriteLine(studentManagers.ToString());//*/

        Console.ReadLine();
    }

    public static void RandomSubject(StudentManager studentManager, string studentNameorID)
    {      
        Random rnd = new Random();
        for (int i = 0; i < rnd.Next(10); i++) 
        {
            string subject = "";
            switch (rnd.Next(8))
            {
                case 0: subject = "Math"; 
                    break;
                case 1: subject = "Chemistry"; 
                    break;
                case 2: subject = "Geography";
                    break;
                case 3: subject = "Biology";
                    break;
                case 4: subject = "P.E.";
                    break;
                case 5: subject = "Physics";
                    break;
                case 6: subject = "Art";
                    break;
                default: subject = "Programming";
                    break;
            }
            studentManager.AddGrade(studentNameorID, subject, rnd.Next(10));
        }        
    }

}