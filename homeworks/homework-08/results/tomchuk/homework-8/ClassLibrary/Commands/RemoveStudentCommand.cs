using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_8
{
    public struct RemoveStudentCommand : ICommand
    {
        private StudentManager _studentManager;
        private Student _toBeRemovedStudent;

        public RemoveStudentCommand(StudentManager studentManager, Student student)
        {
            _studentManager = studentManager;
            _toBeRemovedStudent = student;
        }

        public void Do()
        {
            _studentManager.RemoveStudent(_toBeRemovedStudent);
        }

        public void Undo()
        {
            _studentManager.AddStudent(_toBeRemovedStudent);
        }
    }
}
