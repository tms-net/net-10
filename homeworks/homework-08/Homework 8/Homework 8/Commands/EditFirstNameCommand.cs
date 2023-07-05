using System;
namespace Homework_8
{
	public struct EditFirstNameCommand : ICommand
	{
		private string _previousValue;
		private string _newValue;
		private Student _student;
        private StudentManager _studentManager;

        public EditFirstNameCommand(StudentManager studentManager, Student student, string newName)
		{
			_newValue = newName;
			_student = student;
			_previousValue = student.FirstName;
			_studentManager = studentManager;
		}

		public void Do()
		{
			_studentManager.EditFirstName(_student, _newValue);
		}

		public void Undo()
		{
            _studentManager.EditFirstName(_student, _previousValue);
        }
    }
}

