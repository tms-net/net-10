namespace lib
{
    public class Student
    {
        public Student? _prevStudent = default;
        public string? Name { get; private set; } 
        public decimal Id { get; private set; }
        public decimal Age { get; private set; }
        public decimal Grade { get; private set; }
        public Structs.Gender Gender { get; private set; }

        public Student(string? name, decimal id, decimal age, decimal grade, Structs.Gender gender)
        {
            Name = name;
            Id = id;    
            Age = age;  
            Grade = grade;
            Gender = gender;
        }

        public void ChangeInfo(Student student)
        {
            _prevStudent = new Student(this.Name,this.Id,this.Age,this.Grade,this.Gender);
            Name = student.Name;    
            Id = student.Id;
            Age = student.Age; 
            Grade = student.Grade;
            Gender = student.Gender;
        }

        public void BackUp()
        {
            Name = _prevStudent.Name;
            Id = _prevStudent.Id;
            Age = _prevStudent.Age;
            Grade = _prevStudent.Grade;
            Gender = _prevStudent.Gender;
        }

        public override string ToString()
        {
            return $"{Name}, {Id}, {Age}, {Grade}, {Gender}";
        }
    }
}