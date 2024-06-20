using Zhdanov_Homework_8;

namespace Zhdanov_Hw_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Обновить информацию о студенте");
                Console.WriteLine("3. Удалить студента");
                Console.WriteLine("4. Получить информацию о студенте по идентификатору");
                Console.WriteLine("5. Просмотреть список всех студентов");
                Console.WriteLine("0. Выход");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите имя студента:");
                        string? name = Console.ReadLine();

                        Console.WriteLine("Введите возраст студента:");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите пол студента:");
                        string? gender = Console.ReadLine();

                        Console.WriteLine("Введите факультет студента:");

                        string? faculty = Console.ReadLine();
                        
                        Guid studentId = studentManager.AddStudent(name, age, gender, faculty); 

                        Console.WriteLine($"Студент успешно добавлен, идентификатор студента: {studentId} ");
                                                               
                        break;

                    case "2":
                        Console.WriteLine("Введите идентификатор студента, информацию о котором нужно обновить:");
                        Guid updateId = Guid.Parse(Console.ReadLine());

                        Console.WriteLine("Введите новое имя студента:");
                        string? updatedName = Console.ReadLine();

                        Console.WriteLine("Введите новый возраст студента:");
                        int updatedAge = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите новый пол студента:");
                        string? updatedGender = Console.ReadLine();

                        Console.WriteLine("Введите новый факультет студента:");
                        string? updatedFaculty = Console.ReadLine();

                        studentManager.UpdateStudent(updateId, updatedName, updatedAge, updatedGender, updatedFaculty);

                        Console.WriteLine("Изменения сохранены");
                        break;

                    case "3":
                        Console.WriteLine("Введите идентификатор студента, которого нужно удалить:");
                        Guid removeId = Guid.Parse(Console.ReadLine());

                        studentManager.RemoveStudent(removeId);
                        Console.WriteLine("Студент успешно удален");
                        break;

                    case "4":
                        Console.WriteLine("Введите идентификатор студента, информацию о котором нужно получить:");
                        Guid getId = Guid.Parse(Console.ReadLine());

                        Student? student = studentManager.GetStudentById(getId);
                        if (student != null)
                        {
                            PrintStudentInfo(student);
                        }
                        else
                        {
                            Console.WriteLine("Студент с указанным идентификатором не найден.");
                        }
                        break;

                    
                    case "5":
                        List<Student> allStudents = studentManager.GetAllStudents();
                        if (allStudents.Count > 0)
                        {
                            Console.WriteLine("Список всех студентов:");
                            foreach (Student s in allStudents)
                            {
                                PrintStudentInfo(s);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список студентов пуст.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }

                Console.ReadKey();
            }
        }

        static void PrintStudentInfo(Student student)
        {
            Console.WriteLine($"Идентификатор: {student.Id}");
            Console.WriteLine($"Имя: {student.Name}");
            Console.WriteLine($"Возраст: {student.Age}");
            Console.WriteLine($"Пол: {student.Gender}");
            Console.WriteLine($"Факультет: {student.Faculty}");
        }
    }
}
