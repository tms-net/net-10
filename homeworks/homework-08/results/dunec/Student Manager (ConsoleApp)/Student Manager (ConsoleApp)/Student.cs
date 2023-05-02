using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Manager__ConsoleApp_
{
    internal class Student
    {
        protected string ID { get; }
        protected string StudentName { get; set; }
        protected int Age { get; set; }
        protected string Gender { get; set;}

        public Student(string studentName, int age, string gender) {
            ID = Guid.NewGuid().ToString();
            StudentName = studentName;
            Age = age;
            Gender = gender;
        }

    }
}
