using static Program;
using System.Reflection;
using System;

internal partial class Program
{
    internal class StudentManager : IStudentManager
    {
        List<Student> students = new List<Student>();
        public StudentManager()
        {
            
        }

        public void AddInfo( string firstName, string lastName, int age, double rating, string gender)
        {
            var NewStudent = new Student();
            NewStudent.FirstName = firstName;
            NewStudent.LastName = lastName;
            NewStudent.Age = age;
            NewStudent.Rating = rating;
            NewStudent.Gender = gender;
            students.Add(NewStudent);
        }
        public void AddInfo(string firstNameOld, string lastNameOld, string firstNameNew, string lastNameNew, int age, double rating, string gender)
        {

            if (SerchStudent(firstNameOld, lastNameOld) != null)
            {
                int _searcgIndex = (int)SerchStudent(firstNameOld, lastNameOld);
                students[_searcgIndex].FirstName = firstNameNew;
                students[_searcgIndex].LastName = lastNameNew;
                students[_searcgIndex].Age = age;
                students[_searcgIndex].Rating = rating;
                students[_searcgIndex].Gender = gender;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        public void AddInfo(int SearchID, string firstName, string lastName, int age, double rating, string gender)
        {
            if (IsStudentExists(SearchID) != null)
            {
                int _searcgIndex = (int)IsStudentExists(SearchID);
                students[_searcgIndex].FirstName = firstName;
                students[_searcgIndex].LastName = lastName;
                students[_searcgIndex].Age = age;
                students[_searcgIndex].Rating = rating;
                students[_searcgIndex].Gender = gender;
            }
            else
            {
                throw new ArgumentNullException(nameof(SearchID));
            }
        }
        public void DeleteInfo(int SerchID)
        {
            if (students.Exists(x => x.ID == SerchID))
            {
                students.RemoveAt(students.FindIndex(x => x.ID == SerchID));
            }
            else
            {
                throw new InvalidOperationException($"Студента c ID:{SerchID} не существует");
            }

        }
        public void DeleteInfo(string firstName, string lastName)
        {
            if (students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
            {
                students.RemoveAt(students.FindIndex(x => x.FirstName == firstName && x.LastName == lastName));
            }
            else
            {
                throw new InvalidOperationException($"Студента {firstName} {lastName} не существует");
            }
        }

        public int? IsStudentExists(int serchID) 
        {
            int _resultSearch;
            if (students.Exists(x => x.ID == serchID))
            {
                return _resultSearch = students.FindIndex(x => x.ID == serchID);
            }
            else
            {
                return null;
            }
        }
        public int? SerchStudent(string firstName, string lastName)
        {
            int _resultSearch;
            if (students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
            {
                return _resultSearch = students.FindIndex(x => x.FirstName == firstName && x.LastName == lastName);
            }
            else
            {
                return null;
            }
        }
        
        public Student GetStudent(int index)
        {
            List<Student> allStudents = students.ToList();
            Student student = allStudents[index];
            return student;
        }
        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = students.ToList();
            return allStudents;
        }
    }
    enum ActionState
    {
        Succeeded,
        Failed
    }
}