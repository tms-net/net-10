using System;
namespace Homework_8
{
	public struct EditLastNameCommand : ICommand
	{
        private string _previousValue;
        private string _newValue;
        private Student _student;
        private StudentManager _studentManager;

        public EditLastNameCommand(StudentManager studentManager, Student student, string newName)
        {
            _newValue = newName;
            _student = student;
            _studentManager = studentManager;
            _previousValue = student.LastName;
        }

        public void Do()
        {
            _studentManager.EditLastName(_student, _newValue);
        }

        public void Undo()
        {
            _studentManager.EditLastName(_student, _previousValue);
        }
    }
}

