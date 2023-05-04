using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Manager__ConsoleApp_
{
    internal class SchoolStudent : Student
    {
        public Dictionary<string, Grade> GradesOfSubject { get; set; }
        public SchoolStudent(string studentName, int age, string gender) : base(studentName, age, gender)
        {
            GradesOfSubject = new Dictionary<string, Grade>();
        }

        public void AddGradeOfSubject(string subject, int grade)
        {
            if (grade < 0 || grade > 10)
                throw new ArgumentOutOfRangeException("Inputted grade is out of range of grades");

            GradesOfSubject.Add(subject, (Grade)grade);


        }
    }
}
