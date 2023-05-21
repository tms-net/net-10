using Homework8Lutynski;
using System.Text.Json;
using System.Threading.Channels;
using System.Xml.Linq;

StudentManager studentManager = new StudentManager();
studentManager.FirstSave();
studentManager.ShowMainMenu();
[Serializable]
class StudentManager 
{
    
    List<Student> Students = new List<Student>();
    Stack<string> History = new Stack<string>();
    public StudentManager()
    {
        Console.WriteLine("Добро пожаловать в информационную базу студентов! ");
    }
    public void FirstSave()
    {
        string serialized = JsonSerializer.Serialize(Students);
        History.Push(serialized);
    }
    
    public int studentId = 0;

    internal void ShowMainMenu()
        {
        
        
        Console.WriteLine("Выберите действие:\n1 - Просмотр списка студентов \n2 - Добавить студента \n3 - Удалить студента \n4 - найти студента \n5 - отменить последнее действие");


        string? userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                ShowStudentList();
                break;
            case "2":
                AddStudent();
                break;
            case "3":
                RemoveStudent();
                break;
            case "4":
                SearchStudent(); //не работает, не могу разобраться почему
                break;
            case "5":
                Undo();
                break;
            default: 
                Console.WriteLine("Такой команды не существует");
                ShowMainMenu();
            break;

        }
         
        }
    void ShowStudentList()
    {
        if (Students.Count > 0)
        {
            foreach (var student in Students)
            {
                string s = student.ToString();
                Console.WriteLine(s);
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Список пуст. Нажмите любую клавишу для продолжения.");
            Console.ReadLine();
            
        }
        ShowMainMenu();
    }
    Student AddStudent()
    {
        
        Console.WriteLine("Введите имя студента");
        string? name = Console.ReadLine();

        Console.WriteLine("Введите возраст");
        int age = Convert.ToInt32(Console.ReadLine());

        Student student = new Student(name, AssignId(Students.Count), age, AssignGrade(), AssignGender());

        Students.Add(student);

        string serialized = JsonSerializer.Serialize(Students);
        History.Push(serialized);

        Console.WriteLine("\nСтудент добавлен, нажмите любую клавишу для продолжения.");
        Console.ReadLine();
        
        
        ShowMainMenu();

        return student;
    }
    void RemoveStudent()
    {
        Console.WriteLine("Введите ID студента, которого требуется удалить");
        int IdOfStudentToRemove = Convert.ToInt32(Console.ReadLine());

        int IndexOfStudentToRemove = Students.FindIndex(student =>  student.Id == IdOfStudentToRemove);  
        if (IndexOfStudentToRemove != -1)
        {
            Students.RemoveAt(IndexOfStudentToRemove);
            string serialized = JsonSerializer.Serialize(Students);
            History.Push(serialized);
        }
        else
        {
            Console.WriteLine("Студент не найден");
        }
        ShowMainMenu();
    }
    void SearchStudent()
    {
        Console.WriteLine( "Введите имя искомого студента" );
        string name = Console.ReadLine();
        List<Student> searchResult = new List<Student> (Students.FindIndex(student =>student.Name == name));
        if (searchResult.Count > 0)
        {
            foreach (var student in searchResult)
            {
                string s = student.ToString();
                Console.WriteLine(s);
            }
        }
        else { Console.WriteLine("Ничего не найдено"); }
        ShowMainMenu();
    }
    public void Undo()
    {
        if (History.Count > 1)
        {
            History.Pop(); 
            string previous = History.Peek();
            Students = JsonSerializer.Deserialize<List<Student>>(previous);
            
        }
        else
        {
            Console.WriteLine("No actions to undo.");
        }
        ShowMainMenu();
    }
    
    
    int AssignId(int studentId)
    {
        studentId++;
        return studentId;
    }
    Char AssignGender()
    {
        Console.WriteLine("Введите пол студента: M, F");
        ConsoleKeyInfo charGender = Console.ReadKey();

        switch (charGender.KeyChar)
        {
            case 'M':
                return charGender.KeyChar;
            case 'F':
                return charGender.KeyChar;
            default:
                Console.WriteLine("Некорректный ввод");
                return AssignGender();
        }
        
    }

    int AssignGrade()
    {
        Console.WriteLine( "Введите класс студента");
        int grade = Convert.ToInt32(Console.ReadLine());
        if (grade > 0 && grade <= 11)
        {
            return grade;
        }
        else 
        { 
            Console.WriteLine("Некорректный ввод"); 
            return AssignGrade(); 
        }
    }
    
    
}   
