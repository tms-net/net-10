namespace lib
{
    public class Student
    {
        public string? Name { get; set; } 
        public int Id { get;  set; }
        public int Age { get; set; }
        public int Grade { get;set; }
        public Structs.Gender Gender { get; set; }

        public Student(string? name, int id, int age, int grade, Structs.Gender gender)
        {
            Name = name;
            Id = id;    
            Age = age;  
            Grade = grade;
            Gender = gender;
        }

        public void ChangeInfo(Student student)
        {
            Name = student.Name;    
            Age = student.Age; 
            Grade = student.Grade;
            Gender = student.Gender;
        }

       
        public override string ToString()
        {
            return $"Name: {Name},Age: {Age},Grade: {Grade},Gender: {Gender}";
        }
    }
}