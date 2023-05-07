namespace StudentManagerLibrary
{
    public enum Gender
    {
        Male,
        Femail
    }

    public class Student
    {
        public int Id { get; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public Gender Gender { get; set; }
        public byte Grade { get; set; }

        public Student(int id, string name, byte age, Gender gender, byte grade)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Grade = grade;
            Id = id;
        }

        public override string ToString()
        {
            return $"ID студента - {Id}; Имя студента - {Name}; Возраст студента - {Age}; Пол студента - {Gender}; Оценка студента - {Grade}.\n";
        }
    }
}
    