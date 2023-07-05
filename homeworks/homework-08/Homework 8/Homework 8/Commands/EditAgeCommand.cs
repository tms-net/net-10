using System;
namespace Homework_8
{
	public struct EditAgeCommand : ICommand
	{
        private int _previousValue;
        private int _newValue;
        private Student _student;
        private StudentManager _studentManager;

        public EditAgeCommand(StudentManager studentManager, Student student, int newAge)
        {
            _newValue = newAge;
            _student = student;
            _previousValue = student.Age;
            _studentManager = studentManager;
        }

        public void Do()
        {
            _studentManager.EditAge(_student, _newValue);
        }

        public void Undo()
        {
            _studentManager.EditAge(_student, _previousValue);
        }
    }
}

