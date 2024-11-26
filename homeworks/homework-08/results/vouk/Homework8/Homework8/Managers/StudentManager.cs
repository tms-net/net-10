using StudentsLibrary;

namespace Homework8.Managers
{
    public  class StudentManager
    {
        private  Dictionary<string, List<Student>> _groupsWithStudents = new();

        public  void AddNewGroup(string groupName) => _groupsWithStudents.Add(groupName, new List<Student>());

        public  void RemoveGroup(string groupName) => _groupsWithStudents.Remove(groupName);

        public  void AddStudentToGroup(string groupName, Student student) => _groupsWithStudents[groupName].Add(student);

        public  void RemoveStudentFromGroup(Guid studentId)
        {
            foreach (var groupWithStudent in _groupsWithStudents)
            {
                groupWithStudent.Value.RemoveAll(st => st.Id == studentId);
            }
        }

        public  Student GetUserByFirstName(string firstName) =>
            _groupsWithStudents.SelectMany(s => s.Value).FirstOrDefault(s => s.FirstName == firstName);

        public  Student GetUserByLastName(string lastName) =>
            _groupsWithStudents.SelectMany(s => s.Value).FirstOrDefault(s => s.LastName == lastName);

        public  void BackupStudentChanges(Guid studentId) =>
            _groupsWithStudents.SelectMany(s => s.Value).FirstOrDefault(s => s.Id == studentId).BackupChanges();

        public  void ChangeStudentData(Guid studentId,
                                             string? firstName = null,
                                             string? lastName = null,
                                             DateOnly? birthDate = null,
                                             string? faculty = null,
                                             string? group = null) =>
            _groupsWithStudents.SelectMany(s => s.Value)
                               .FirstOrDefault(s => s.Id == studentId)
                               .ChangeStudentData(
                                   firstName,
                                   lastName,
                                   birthDate,
                                   faculty,
                                   group);
    }
}