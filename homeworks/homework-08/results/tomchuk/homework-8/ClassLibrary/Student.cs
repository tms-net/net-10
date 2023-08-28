using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Homework_8
{
    
    public class Student
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; } = "uknown";
        public string LastName { get; set; } = "uknown";
        public int Age { get; set; } = 0;
        public Gender Gender { get; set; } = Gender.M;
        public List<int> Marks { get; set; }

        public Student()
        {
            ID = Guid.NewGuid();
            Marks = new List<int>();
        }

        public void AddMark(int mark)
        {
            if (mark >= 0)
            {
                Marks.Add(mark);
            }
        }

        public void RemoveLastMark()
        {
            Marks.RemoveAt(Marks.Count - 1);
        }

        public void EditFirstName(string newFirstName)
        {
            if (newFirstName != null)
            {
                FirstName = newFirstName;
            }
        }

        public void EditLastName(string newLastName)
        {
            if (newLastName != null)
            {
                LastName = newLastName;
            }
        }

        public void EditGender(Gender newGender)
        {
            Gender = newGender;
        }

        public void EditAge(int newAge)
        {
            if (newAge > 0)
            {
                Age = newAge;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Gender}, {Age}";
        }
    }
}
