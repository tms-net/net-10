using StudentManager;

namespace StudentManagerLibrary
{
    public class StudentManager
    {
        private Dictionary<int, Student> _students = new Dictionary<int, Student>();
        private Stack<ICommand> _commands = new Stack<ICommand>();

        public Student AddStudent(string name, byte age, Gender gender, byte grade)
        {
            var studentId = _students.Count;
            var student = new Student(studentId, name, age, gender, grade);

            var command = new AddStudentCommand(_students, student);
            command.Execute();
            _commands.Push(command);

            return student;
        }

        public void UpdateStudent(int id, Student updatedStudent)
        {
            var command = new UpdateStudentCommand(_students, id, updatedStudent);
            command.Execute();
            _commands.Push(command);
        }

        public void RemoveStudent(int id)
        {
            if (_students.TryGetValue(id, out var student))
            {
                var command = new RemoveStudentCommand(_students, student);
                command.Execute();
                _commands.Push(command);
            }
        }

        public Student GetStudentById(int id)
        {
            _students.TryGetValue(id, out var student);
            return student;
        }

        public IEnumerable<Student> GetStudentsByName(string name)
        {
            return _students.Values.Where(s => s.Name == name);
        }

        public void UndoLastOperation()
        {
            if (_commands.Count > 0)
            {
                var command = _commands.Pop();
                command.Undo();
            }
        }
    }
}
