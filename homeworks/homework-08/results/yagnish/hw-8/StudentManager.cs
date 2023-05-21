using lib;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using static lib.Structs;
using System.Xml.Linq;

namespace hw_8
{
    internal class StudentManager
    {
        public Student? _prevStudent = default;

        public Dictionary<int, Student> _students;

        public StudentManager()
        {
           _students = new Dictionary<int, Student>();
        }

        public void AddStudent(Student student) { _students.TryAdd(student.Id, student); }

        public void DeleteStudent(Student student)=>_students.Remove(student.Id);

        public bool FindStudent(int id, out Student? student) 
        {
            if (_students.ContainsKey(id))
            {
                student = _students[id];
                return true;
            }
            student = null;
            return false;
        }

        public bool FindStudent(string? name, out Student? student)
        {
            var st = (_students.Values.FirstOrDefault(x => x.Name == name));
            if (st!=null)
            {
                student =st;
                return true;
            }
            student = null;
            return false;
        }

        public void BackUp(Student student)
        {
            student.Name = _prevStudent.Name;
            student.Id = _prevStudent.Id;
            student.Age = _prevStudent.Age;
            student.Grade = _prevStudent.Grade;
            student.Gender = _prevStudent.Gender;
        }

    }
}
