using Homework8.Managers;
using StudentsLibrary;

namespace Homework8
{
    public class Program
    {
        private const string FirstGroupName = "Group 1";
        private const string SecondGroupName = "Group 2";

        static void Main(string[] args)
        {
            StudentManager studentManager = new();

            // Add two groups
            studentManager.AddNewGroup(FirstGroupName);
            studentManager.AddNewGroup(SecondGroupName);

            // Add student to the first group
            studentManager.AddStudentToGroup(FirstGroupName, new Student("Ivan", "Ivanov", DateOnly.MaxValue, "Computer Science", FirstGroupName));
            studentManager.AddStudentToGroup(FirstGroupName, new Student("Sidor", "Sidorov", DateOnly.MinValue, "Biology Science", FirstGroupName));

            // Add student to the second group
            studentManager.AddStudentToGroup(SecondGroupName, new Student("Petr", "Petrov", DateOnly.MaxValue, "Machine Science", SecondGroupName));
            studentManager.AddStudentToGroup(SecondGroupName, new Student("Sidor", "Sidorov", DateOnly.MinValue, "Electronic Science", SecondGroupName));

            // Remove Sidor from group
            studentManager.RemoveStudentFromGroup(studentManager.GetUserByFirstName("Sidor").Id);

            // Change Petr Petrov Last Name
            studentManager.ChangeStudentData(studentManager.GetUserByFirstName("Petr").Id, lastName: "Petrovich");

            // Get Ivanov and Petrovich students
            var ivanIvanovStudent = studentManager.GetUserByFirstName("Ivan");

            // Back Petr Last Name to the previous
            studentManager.BackupStudentChanges(studentManager.GetUserByLastName("Petrovich").Id);
        }
    }
}