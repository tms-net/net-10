using StudentManagerLibrary;

namespace StudentManager
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class AddStudentCommand : ICommand
    {
        private Dictionary<int, Student> _students;
        private Student _student;

        public AddStudentCommand(Dictionary<int, Student> students, Student student)
        {
            _students = students;
            _student = student;
        }

        public void Execute()
        {
            _students.Add(_student.Id, _student);
        }

        public void Undo()
        {
            _students.Remove(_student.Id);
        }
    }

    public class UpdateStudentCommand : ICommand
    {
        private Dictionary<int, Student> _students;
        private int _id;
        private Student _updatedStudent;
        private Student _oldStudent;

        public UpdateStudentCommand(Dictionary<int, Student> students, int id, Student updatedStudent)
        {
            _students = students;
            _id = id;
            _updatedStudent = updatedStudent;
            _students.TryGetValue(id, out _oldStudent);
        }

        public void Execute()
        {
            if (_students.ContainsKey(_id))
            {
                _students[_id] = _updatedStudent;
            }
        }

        public void Undo()
        {
            if (_students.ContainsKey(_id))
            {
                _students[_id] = _oldStudent;
            }
        }
    }

    public class RemoveStudentCommand : ICommand
    {
        private Dictionary<int, Student> _students;
        private Student _student;

        public RemoveStudentCommand(Dictionary<int, Student> students, Student student)
        {
            _students = students;
            _student = student;
        }

        public void Execute()
        {
            _students.Remove(_student.Id);
        }

        public void Undo()
        {
            _students.Add(_student.Id, _student);
        }
    }
}
