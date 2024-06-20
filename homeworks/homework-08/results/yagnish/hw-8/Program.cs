using lib;
namespace hw_8
{
    internal class Program
    {
        static StudentManager studentManager = new StudentManager();
        static void Main(string[] args)
        {

            bool fl = true;
            while (fl)
            {
                Console.WriteLine(@"1.Add new student
2.Delete sudent
3.Update student info
4.Get student info
5.Backup previous operation
6.See all students
7.Finish program");
                Console.WriteLine("Enter action number");

                switch (Console.ReadLine())
                {
                    case "1":
                        studentManager.AddStudent(MakeNewStudent());
                        break;
                    case "2":
                        studentManager.DeleteStudent(Find());
                        break;
                    case "3":
                        studentManager._students[Find().Id].ChangeInfo(MakeNewStudent());
                        break;
                    case "4":
                        Console.WriteLine(Find().ToString());
                        break;
                    case "5":
                        studentManager.BackUp(Find());
                        break;
                    case "6":
                        foreach(var student in studentManager._students)
                            Console.WriteLine(student.ToString());
                        break;
                    case "7":
                        fl = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        private static Student Find()
        {
            int id_input;
            string? _input = "";
            Student? student;
            Console.WriteLine("Enter student id/name:");
            _input = Console.ReadLine();

            if (!studentManager.FindStudent(_input, out student))
            {
                Int32.TryParse(_input, out id_input);
                if (!studentManager.FindStudent(id_input, out student))
                    throw new Exception("No such student Id/name");
            }
            return student;

        }
        private static Student MakeNewStudent()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Age: ");
            int age;
            string? inp = Console.ReadLine();
            Int32.TryParse(inp, out age);
            Console.WriteLine("Gender(m/f): ");
            inp = Console.ReadLine();
            Structs.Gender gender = default;
            bool fl = true;
            while (fl)
            {
                switch (inp)
                {
                    case "m":
                        gender = Structs.Gender.Male;
                        fl = false;
                        break;
                    case "f":
                        gender = Structs.Gender.Female;
                        fl = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Try again");
                        break;
                }
            }
            Console.WriteLine("Grade");
            inp = Console.ReadLine();
            int grade;
            Int32.TryParse(inp, out grade);
            return new Student(name, studentManager._students.Count + 1, age, grade, gender);
        }
    }
}