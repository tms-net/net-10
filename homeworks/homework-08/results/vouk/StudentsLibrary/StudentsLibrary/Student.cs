namespace StudentsLibrary
{
    public class Student
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public string? Faculty { get; private set; }
        public string? Group { get; private set; }
        public Guid Id { get; private set; }

        private Student _previousStudentState;

        public Student(string? firstName, string? lastName, DateOnly birthDate, string? faculty, string? group)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Faculty = faculty;
            Group = group;
            Id = Guid.NewGuid();
        }

        private Student(Student previousStudentState)
        {
            FirstName = previousStudentState.FirstName;
            LastName = previousStudentState.LastName;
            BirthDate = previousStudentState.BirthDate;
            Faculty = previousStudentState.Faculty;
            Group = previousStudentState.Group;
            Id = previousStudentState.Id;
        }

        public void ChangeStudentData(string? firstName = null, string? lastName = null, DateOnly? birthDate = null, string? faculty = null, string? group = null)
        {
            _previousStudentState = new Student(this);
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            BirthDate = birthDate ?? BirthDate;
            Faculty = faculty ?? Faculty;
            Group = group ?? Group;
        }
        public void BackupChanges()
        {
            FirstName = _previousStudentState.FirstName;
            LastName = _previousStudentState.LastName;
            BirthDate = _previousStudentState.BirthDate;
            Faculty = _previousStudentState.Faculty;
            Group = _previousStudentState.Group;
            _previousStudentState = new Student(this);
        }
    }
}