using EnititesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KlindyukHW8
{
    public class StudentManager : IManageStudent, IBackup
    {
        private Dictionary<uint, Student> studentsData = new Dictionary<uint, Student>();
        private Dictionary<uint, string> studenstIdAndName = new Dictionary<uint, string>();
        private Dictionary<uint, Student> backupStudentsData;
        private Dictionary<uint, string> backupStudenstIdAndName;

        public string AddStudent(string name, byte age, char gender, byte grade)
        {
            SaveChanges();
            var newStudent = new Student(name, age, gender, grade);
            studentsData.Add(newStudent.Id, newStudent);
            studenstIdAndName.Add(newStudent.Id, newStudent.Name);
            return $"Student {newStudent.Id} was added";
        }

        public string GetAllStudentInfo()
        {
            string result = $"There are {studentsData.Count} students on the list\n\n";
            if (studentsData.Count > 0)
            {
                foreach (var student in studentsData)
                {
                    result += student.Value;
                }
            }
            return result;
        }

        public string GetInfoById(uint id)
        {
            if (studentsData.ContainsKey(id))
            {
                return $"{studentsData[id]}";
            }
            else
            {
                return "Student with this Id was not found";
            }
        }

        public string GetInfoByName(string name)
        {
            if (studenstIdAndName.ContainsValue(name))
            {
                uint id = studenstIdAndName.Where(x => x.Value == name).FirstOrDefault().Key;
                return $"{studentsData[id]}";
            }
            else
            {
                return "Student with this Name was not found";
            }
        }

        public string UpdateStudentInfo(uint id, string name, byte age, char gender, byte grade)
        {
            if (studentsData.ContainsKey(id))
            {
                SaveChanges();
                studentsData[id] = new Student(name, age, gender, grade);
                studenstIdAndName[id] = name;
                return $"Student {id} was updated";
            }
            else
            {
                return "Student with this id was not found";
            }
        }

        public string RemoveStudent(uint id)
        {
            if (studentsData.ContainsKey(id))
            {
                SaveChanges();
                studentsData.Remove(id);
                studenstIdAndName.Remove(id);
                return $"Student {id} was deleted";
            }
            else
            {
                return "Student with this id was not found";
            }
        }

        public void SaveChanges()
        {
            backupStudentsData = new Dictionary<uint, Student>(studentsData);
            backupStudenstIdAndName = new Dictionary<uint, string>(studenstIdAndName);
        }

        public void LoadChanges()
        {
            if (backupStudentsData.Count != 0)
            {
                studentsData = new Dictionary<uint, Student>(backupStudentsData);
                studenstIdAndName = new Dictionary<uint, string>(backupStudenstIdAndName);
            }
        }

        public bool checkId(uint id) => studentsData.ContainsKey(id);
    }
}
