using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Homework8Lutynski
{
    
    internal class Student
    {
        public string Name { get; set; }
        public int Id { get; }
        public int Age { get; set; }
        public Char Gender { get; set; }
        public int Grade { get; set; }

        public Student(string name, int id, int age, int grade, Char gender)
        {
            Console.WriteLine($"Name: {name}, Id: {id}, Age: {age}, Gender: {gender}, Grade: {grade}");
            Name = name;
            Id = id;
            Age = age;
            Gender = gender;
            Grade = grade;
        }

        public override string ToString()
        {
            string toString = $"ID: {Id}, Name: {Name}, {Grade}-th Grade, Age: {Age}, Gender: {Gender}.";
            return toString;
        }
        internal void EditInfo()
        {

        }
    }
}
