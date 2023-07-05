using System;
namespace Homework_8
{
	public struct AddMarkCommand : ICommand
	{
        private int _newMark;
        private Student _student;
        private StudentManager _studentManager;

        public AddMarkCommand(StudentManager studentManager, Student student, int newMark)
        {
            _newMark = newMark;
            _student = student;
            _studentManager = studentManager;
        }

        public void Do()
        {
            _studentManager.AddMark(_student, _newMark);
        }

        public void Undo()
        {
            _student.RemoveLastMark();
        }
    }
}

