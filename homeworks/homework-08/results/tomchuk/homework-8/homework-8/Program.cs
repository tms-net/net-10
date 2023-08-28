using Homework_8;
using System;

Console.WriteLine("Hello it's Student Maneger");
StudentManager sm = new StudentManager();

Student student1 = new Student()
{
    FirstName = "Sasha",
    LastName = "Petrov",
    Age = 18,
    Gender = Gender.M
};

Student student2 = new Student()
{
    FirstName = "Maxim",
    LastName = "Butko",
    Age = 19,
    Gender = Gender.M,
    Marks = new List<int>() { 5, 5 }
};

Student student3 = new Student()
{
    FirstName = "Katya",
    LastName = "Ivanova",
    Age = 17,
    Gender = Gender.F,
    Marks = new List<int>() { 4 }
};

Student student4 = new Student()
{
    FirstName = "Pasha",
    LastName = "Dunin",
    Age = 18,
    Gender = Gender.M,
    Marks = new List<int>() { 5, 5, 5 }
};

AddStudentCommand addStudent = new AddStudentCommand(sm, student1);
addStudent = new AddStudentCommand(sm, student1);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student2);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student3);
sm.CallCommand(addStudent);
addStudent = new AddStudentCommand(sm, student4);
sm.CallCommand(addStudent);

Console.Write($"{sm.Students.Count} students have been added:");
sm.ConsoleOutCurrentListOfUsers();

var removeStudent = new RemoveStudentCommand(sm, student2);
sm.CallCommand(removeStudent);
Console.Write("\n\n student has been removed:");
sm.ConsoleOutCurrentListOfUsers();

sm.UndoCommand();
Console.Write("\n\nUndo removing student:");
sm.ConsoleOutCurrentListOfUsers();

var addMark = new AddMarkCommand(sm, student4, 2);
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
Console.Write("\n\nUndo changes of age student:");
sm.ConsoleOutCurrentListOfUsers();

