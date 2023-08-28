using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_8
{
    public struct AddStudentCommand : ICommand
    {
        private StudentManager _studentManager;
        private Student _newStudent;

        public AddStudentCommand(StudentManager studentManager, Student student)
        {
            _newStudent = student;
            _studentManager = studentManager;
        }

        public void Do()
        {
            _studentManager.AddStudent(_newStudent);
        }

        public void Undo()
        {
            _studentManager.RemoveStudent(_newStudent);
        }
    }
}
