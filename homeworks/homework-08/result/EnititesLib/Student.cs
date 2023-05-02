namespace EnititesLib
{
    internal class Student
    {
        internal uint Id { get; }
        internal string Name { get; }
        byte Age { get; }
        char Gender { get; }
        byte Grade { get; }
        Random rnd = new Random();

        internal Student(
                string name,
                byte age,
                char gender,
                byte grade)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Grade = grade;
            Id = (uint)rnd.Next(4000, 4999 + 1);
        }

        public override string ToString() => $"ID: {Id}\nName: {Name}\nAge: {Age}\nGender: {Gender}\nGrade:{Grade}\n\n";
    }
}