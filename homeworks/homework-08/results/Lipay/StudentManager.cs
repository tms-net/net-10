using static Program;
using System.Reflection;
using System;

internal partial class Program
{
    internal class StudentManager : IStudentManager
    {
        ActionState actionState = new ActionState();
        List<Student> students = new List<Student>();
        public StudentManager()
        {
            
        }

        public void AddInfo( string firstName, string lastName, int age, double rating, string gender)
        {
            students.Add(new Student());
            students[students.Count - 1].FirstName = firstName;
            students[students.Count - 1].LastName = lastName;
            students[students.Count - 1].Age = age;
            students[students.Count - 1].Rating = rating;
            students[students.Count - 1].Gender = gender;
        }
        public void AddInfo(int index, string firstName, string lastName, int age, double rating, string gender)
        {
            
            students[index].FirstName = firstName;
            students[index].LastName = lastName;
            students[index].Age = age;
            students[index].Rating = rating;
            students[index].Gender = gender;
        }
        public void DeleteInfo(int SerchID)
        {
            if (students.Exists(x => x.ID == SerchID))
            {
                students.RemoveAt(students.FindIndex(x => x.ID == SerchID));
                actionState = ActionState.Succeeded; 
            }
            else actionState = ActionState.Failed;

        }
        public void DeleteInfo(string firstName, string lastName)
        {
            students.RemoveAt(students.FindIndex(x => x.FirstName == firstName && x.LastName == lastName));
        }

        public int? SerchStudent(int serchID) 
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