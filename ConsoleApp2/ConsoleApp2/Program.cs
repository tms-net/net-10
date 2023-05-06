using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Group { get; set; }
}

public class Operation
{
    public string Type { get; set; }
    public object Data { get; set; } 
}

public class StudentManager
{
    private List<Student> students = new List<Student>();
    private Stack<Operation> operations = new Stack<Operation>();

    public void AddStudent(Student student)
    {
        students.Add(student);
        operations.Push(new Operation { Type = "Add", Data = student });
    }

    public void UpdateStudent(Student student)
    {
        var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
        if (existingStudent != null)
        {
            operations.Push(new Operation { Type = "Update", Data = existingStudent });
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Group = student.Group;
        }
    }

    public void DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            students.Remove(student);
            operations.Push(new Operation { Type = "Delete", Data = student });
        }
    }

    public Student GetStudentById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetStudentsByName(string name)
    {
        return students.Where(s => s.FirstName == name || s.LastName == name).ToList();
    }

    public void UndoLastOperation()
    {
        if (operations.Count > 0)
        {
            var operation = operations.Pop();
            switch (operation.Type)
            {
                case "Add":
                    var student = (Student)operation.Data;
                    students.Remove(student);
                    break;
                case "Update":
                    var existingStudent = (Student)operation.Data;
                    students.FirstOrDefault(s => s.Id == existingStudent.Id)?.CopyFrom(existingStudent);
                    break;
                case "Delete":
                    var deletedStudent = (Student)operation.Data;
                    students.Add(deletedStudent);
                    break;
            }
        }
    }
}

public static class Extensions
{
    public static void CopyFrom(this Student target, Student source)
    {
        target.FirstName = source.FirstName;
        target.LastName = source.LastName;
        target.DateOfBirth = source.DateOfBirth;
        target.Group = source.Group;
    }
}

public class Program
{
    private static StudentManager manager = new StudentManager();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Обновить информацию о студенте");
            Console.WriteLine("3. Удалить студента");
            Console.WriteLine("4. Получить информацию о студенте по ID");
            Console.WriteLine("5. Получить информацию о студенте по имени");
            Console.WriteLine("6. Отменить последнюю операцию");
            Console.WriteLine("7. Выйти из программы");

            Console.Write("Введите номер операции: ");
            var input = Console.ReadLine();


//Кнопки и смена цвета текста

            int id;
            switch (input)
            {
    case "1":
        var student = new Student();
        Console.Write("Введите имя: ");
        student.FirstName = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        student.LastName = Console.ReadLine();
        Console.Write("Введите дату рождения (гггг-мм-дд): ");
        student.DateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите группу: ");
        student.Group = Console.ReadLine();
        manager.AddStudent(student);
        Console.WriteLine("Студент добавлен.");
        break;
    case "2":
        var updatedStudent = new Student();
        Console.Write("Введите ID студента: ");
        id = int.Parse(Console.ReadLine());
        updatedStudent.Id = id;
        Console.Write("Введите имя: ");
        updatedStudent.FirstName = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        updatedStudent.LastName = Console.ReadLine();
        Console.Write("Введите дату рождения (гггг-мм-дд): ");
        updatedStudent.DateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите группу: ");
        updatedStudent.Group = Console.ReadLine();
        manager.UpdateStudent(updatedStudent);
        Console.WriteLine("Информация о студенте обновлена.");
        break;
    case "3":
        Console.Write("Введите ID студента: ");
        id = int.Parse(Console.ReadLine());
        manager.DeleteStudent(id);
        Console.WriteLine("Студент удален.");
        break;
    case "4":
        Console.Write("Введите ID студента: ");
        id = int.Parse(Console.ReadLine());
        var studentById = manager.GetStudentById(id);
        if (studentById != null)
        {
            Console.WriteLine($"ID: {studentById.Id}, Имя: {studentById.FirstName}, Фамилия: {studentById.LastName}, Дата рождения: {studentById.DateOfBirth.ToShortDateString()}, Группа: {studentById.Group}");
        }
        else
        {
            Console.WriteLine("Студент не найден.");
        }
        break;
    case "5":
        Console.Write("Введите имя или фамилию студента: ");
        var name = Console.ReadLine();
        var studentsByName = manager.GetStudentsByName(name);
        if (studentsByName.Count > 0)
        {
            foreach (var studentByName in studentsByName)
            {
                Console.WriteLine($"ID: {studentByName.Id}, Имя: {studentByName.FirstName}, Фамилия: {studentByName.LastName}, Дата рождения: {studentByName.DateOfBirth.ToShortDateString()}, Группа: {studentByName.Group}");
            }
        }
        else
        {
            Console.WriteLine("Студенты не найдены.");
        }
        break;
    case "6":
        manager.UndoLastOperation();
        Console.WriteLine("Последняя операция отменена.");
        break;
    case "7":
        return;
    default:
        Console.WriteLine("Некорректный номер операции.");
        break;
}
        }
    }
}


