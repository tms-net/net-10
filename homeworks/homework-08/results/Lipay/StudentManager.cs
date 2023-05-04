using static Program;
using System.Reflection;

internal partial class Program
{
    internal class StudentManager : IStudentManager
    {

        public StudentManager()
        {

        }

        public void AddInfo(Student student, string firstName, string lastName, int age, double rating, string gender)
        {
            student.FirstName = firstName;
            student.LastName = lastName;
            student.Age = age;
            student.Rating = rating;
            student.Gender = gender;
        }

        public void DeleteInfo(List<Student> student, int SerchID)
        {
            student.RemoveAt(student.FindIndex(x => x.ID == SerchID));
        }
        public void DeleteInfo(List<Student> student, string firstName, string lastName)
        {
            student.RemoveAt(student.FindIndex(x => x.FirstName == firstName && x.LastName == lastName));
        }
    }
}