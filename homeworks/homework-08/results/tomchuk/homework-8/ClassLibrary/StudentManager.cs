using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_8
{
    public class StudentManager
    {
        private readonly Dictionary<Guid, Student> _students; //contains unique Id and a reference to student
        private readonly Dictionary<Guid, string> _studentsId; //contans <"first_name+last_name" , unique_id> for searching by firstname/lastname
        private readonly Stack<ICommand> _commandHistory;

        public Dictionary<Guid, Student> Students => _students;

        public StudentManager()
        {
            _students = new Dictionary<Guid, Student>();
            _studentsId = new Dictionary<Guid, string>();

            _commandHistory = new Stack<ICommand>();
        }

        public void CallCommand(ICommand newCommand)
        {
            newCommand.Do();
            _commandHistory.Push(newCommand);
        }

        public void UndoCommand()
        {
            if (_commandHistory.Count > 0)
            {
                var deniedCommand = _commandHistory.Pop();
                deniedCommand.Undo();
            }
        }

        public void AddStudent(Student newStudent)
        {
            _students.Add(newStudent.ID, newStudent);
            _studentsId.Add(newStudent.ID, $"{newStudent.FirstName.ToLower()}{newStudent.LastName.ToLower()}");
        }

        public bool RemoveStudent(Student student)
        {
            if (_students.ContainsKey(student.ID))
            {
                _students.Remove(student.ID);
                _studentsId.Remove(student.ID);
                return true;
            }

            return false;
        }

        public void EditFirstName(Student student, string newFirstName)
        {
            if (_students.ContainsKey(student.ID))
            {
                student.FirstName = newFirstName;
                UpdateNames(student);
            }
        }

        public void EditLastName(Student student, string newLastName)
        {
            if (_students.ContainsKey(student.ID))
            {
                student.LastName = newLastName;
                UpdateNames(student);
            }
        }

        public void EditGender(Student student, Gender newGender)
        {
            if (_students.ContainsKey(student.ID))
            {
                student.Gender = newGender;
            }
        }

        public void EditAge(Student student, int newAge)
        {
            if (_students.ContainsKey(student.ID))
            {
                student.Age = newAge;
            }
        }

        public void AddMark(Student student, int mark)
        {
            if (_students.ContainsKey(student.ID))
            {
                student.AddMark(mark);
            }
        }

        public void RemoveLastMark(Student student)
        {
            if (_students.ContainsKey(student.ID))
            {
                student.RemoveLastMark();
            }
        }

        public Student SearchById(Guid id)
        {
            if (_students.ContainsKey(id))
            {
                return _students[id];
            }

            return new Student();
        }


        public void UpdateNames(Student student)
        {
            foreach (Guid key in _studentsId.Keys)
            {
                if (key == student.ID)
                {
                    _studentsId[key] = $"{student.FirstName.ToLower()}{student.LastName.ToLower()}";
                }
            }
        }

        public void ConsoleOutCurrentListOfUsers()
        {
            Console.Write("\n\n>>>>>List of students:<<<<<");

            if (_students.Count == 0)
            {
                Console.Write("\nNo students");
                return;
            }
            int i = 0;
            foreach (Guid key in _students.Keys)
            {
                
                Console.Write($"\n{i++}) {_students[key].ToString()}, Marks: ");

                if (_students[key].Marks.Count > 0)
                {
                    foreach (int mark in _students[key].Marks)
                    {
                        Console.Write($"{mark} ");
                    }
                }
                else
                {
                    Console.Write("no marks");
                }
            }
        }
    }
}
