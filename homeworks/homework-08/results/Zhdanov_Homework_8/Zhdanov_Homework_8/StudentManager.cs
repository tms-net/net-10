using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_Homework_8
{
    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public Guid AddStudent(string name, int age, string gender, string faculty)
        {
            Student newStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                Gender = gender,
                Faculty = faculty
            };

            students.Add(newStudent);
            
            return newStudent.Id;
        }

        public void UpdateStudent(Guid id, string name, int age, string gender, string faculty)
        {
            Student? student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return;
            }

            student.Name = name;
            student.Age = age;
            student.Gender = gender;
            student.Faculty = faculty;
        }

        public void RemoveStudent(Guid id)
        {
            Student? student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return;
            }

            students.Remove(student);
        }

        public Student? GetStudentById(Guid id)
        {
            Student? student = students.Find(s => s.Id == id);
            return student;
        }

       
        public List<Student> GetAllStudents()
        {
            return new List<Student>(students);
        }

    }
}
