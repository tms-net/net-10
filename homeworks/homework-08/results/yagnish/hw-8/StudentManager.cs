using lib;
using System.Diagnostics.Contracts;

namespace hw_8
{
    internal class StudentManager
    {
        public Dictionary<decimal, Student> _students;

        public StudentManager()
        {
           _students = new Dictionary<decimal, Student>();
        }

        public void AddStudent(Student student) { _students.TryAdd(student.Id, student); }

        public void DeleteStudent(Student student)=>_students.Remove(student.Id);

        public bool FindStudent(decimal id, out Student? student) 
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



    }
}
