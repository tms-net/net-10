using Homework_8;

StudentManager sm = new StudentManager();
Student student0 = new Student()
    {
        FirstName = "Dave",
        LastName = "Gabe",
        Age = 18,
        Gender = Gender.M
    };

Student student1 = new Student()
{
    FirstName = "Amanda",
        LastName = "Stone",
        Age = 18,
        Gender = Gender.F
    };

Student student2 = new Student()
{
    FirstName = "Marc",
        LastName = "Table",
        Age = 19,
        Gender = Gender.M,
        Marks = new List<int>() { 5, 5 }
    };

Student student3 = new Student()
{
    FirstName = "Katie",
        LastName = "Wonder",
        Age = 17,
        Gender = Gender.F,
        Marks = new List<int>() { 4 }
    };

Student student4 = new Student()
{
    FirstName = "Tonny",
        LastName = "Soyer",
        Age = 18,
        Gender = Gender.M,
        Marks = new List<int>() { 5, 5, 5 }
    };

AddStudentCommand addStudent = new AddStudentCommand(sm, student0);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student1);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student2);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student3);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student4);
sm.CallCommand(addStudent);
Console.Write("\n\n5 students have been added:");
sm.ConsoleOutCurrentListOfUsers();

var removeStudent = new RemoveStudentCommand(sm, student2);
sm.CallCommand(removeStudent);
Console.Write("\n\n2nd student has been removed:");
sm.ConsoleOutCurrentListOfUsers();

sm.UndoCommand();
Console.Write("\n\nUndo removing 2 student:");
sm.ConsoleOutCurrentListOfUsers();

var addMark = new AddMarkCommand(sm, student4, 7);
sm.CallCommand(addMark);
Console.Write("\n\nA new mark added for the last student:");
sm.ConsoleOutCurrentListOfUsers();

var editFirstNameCommand = new EditFirstNameCommand(sm, student4, "EditedFirstName");
sm.CallCommand(editFirstNameCommand);
Console.Write("\n\nChanged first name for the last student:");
sm.ConsoleOutCurrentListOfUsers();

var editLastNameCommand = new EditLastNameCommand(sm, student4, "EditedLastName");
sm.CallCommand(editLastNameCommand);
Console.Write("\n\nChanged last name for the last student:");
sm.ConsoleOutCurrentListOfUsers();

var editAgeCommand = new EditAgeCommand(sm, student4, 19);
sm.CallCommand(editAgeCommand);
Console.Write("\n\nChanged Age for the last student:");
sm.ConsoleOutCurrentListOfUsers();

sm.UndoCommand();
Console.Write("\n\nUndo changes of age 4 student:");
sm.ConsoleOutCurrentListOfUsers();

string searchPattern = "on";
List<Student> foundSt = sm.SearchByName(searchPattern);
if(foundSt.Count > 0)
{
    Console.Write($"\n\nSearch result by pattern \"{searchPattern}\":");
    foreach(Student student in foundSt)
    {
        Console.Write($"\n{student.ToString()}");
    }
}

searchPattern = "ted";
foundSt = sm.SearchByName(searchPattern);
if (foundSt.Count > 0)
{
    Console.Write($"\n\nSearch result by pattern \"{searchPattern}\":");
    foreach (Student student in foundSt)
    {
        Console.Write($"\n{student.ToString()}");
    }
}



