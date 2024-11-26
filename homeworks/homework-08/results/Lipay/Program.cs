using System;
using System.Reflection;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Программа: Менеджер студентов");

       
        StudentManager studentManager= new StudentManager();
        
        
        while (true)
        {

            Console.WriteLine("Выберите вариант действие:");
            Console.WriteLine(
                "1 - Добавление информации о новых студентах" +
                "\r\n2 - Обновление информации о студенте" +
                "\r\n3 - Удаление информации о студенте" +
                "\r\n4 - Получение информации о студенте по идентификатору" +
                "\r\n5 - Получение информации о студенте по фамилии/имени" +
                "\r\n6 - Получение информации о всех студентах");
            int options;

            while (true)
            {
                string? input = Console.ReadLine();

                bool result1 = int.TryParse(input, out var number);
                if (result1 == true && number > 0 && number < 7)
                {
                    options = number;
                    break;
                }
                else
                    Console.WriteLine("Введите коректное значение действия");
            }
            switch (options)
            {
                case 1:

                    Console.Write("Введите имя: ");
                    string? firstName = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string? lastName = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    int age;
                    while (true)
                    {
                        string? input = Console.ReadLine();

                        bool result = int.TryParse(input, out var number);
                        if (result == true && number > 0 && number < 100)
                        {
                            age = number;
                            break;
                        }
                        else
                            Console.WriteLine("Введите коректное значение действия");
                    }
                    Console.Write("Выберите пол(М/Ж): ");
                    string gender;
                    while (true)
                    {
                        string? input = Console.ReadLine();
                        if (input == "М")
                        {
                            gender = input;
                            break;
                        }
                        else if (input == "Ж")
                        {
                            gender = input;
                            break;
                        }
                        else
                            Console.WriteLine("Введите коректное значение: \"М\" или \"Ж\"");
                    }

                    Console.Write("Введите рейтинг студента: ");
                    double rating = double.Parse(Console.ReadLine());

     
                    studentManager.AddInfo(firstName, lastName, age, rating, gender);

                    break;
                case 2:
                    int? resultSearch;
                    Console.WriteLine("Найдите студента, информацию о котором Вы хотите обновить");
                    Console.WriteLine("Выберите режим поиска:\n1 - по ID\n2 - по Имени и Фамилии");
                    while (true)
                    {
                        string? input = Console.ReadLine();

                        bool result1 = int.TryParse(input, out var number);
                        if (result1 == true && number > 0 && number < 3)
                        {
                            options = number;
                            break;
                        }
                        else
                            Console.WriteLine("Введите коректное значение действия");
                    }
                    if (options == 1)
                    {
                        Console.Write("Введите ID для поиска: ");
                        int SerchID = int.Parse(Console.ReadLine());
                        resultSearch = studentManager.IsStudentExists(SerchID);
                        if (resultSearch != null)
                        {
                            
                            Console.Write("Введите имя: ");
                            firstName = Console.ReadLine();
                            Console.Write("Введите фамилию: ");
                            lastName = Console.ReadLine();
                            Console.Write("Введите возраст: ");

                            while (true)
                            {
                                string? input = Console.ReadLine();

                                bool result = int.TryParse(input, out var number);
                                if (result == true && number > 0 && number < 100)
                                {
                                    age = number;
                                    break;
                                }
                                else
                                    Console.WriteLine("Введите коректное значение действия");
                            }
                            Console.Write("Выберите пол(М/Ж): ");

                            while (true)
                            {
                                string? input = Console.ReadLine();
                                if (input == "М")
                                {
                                    gender = input;
                                    break;
                                }
                                else if (input == "Ж")
                                {
                                    gender = input;
                                    break;
                                }
                                else
                                    Console.WriteLine("Введите коректное значение: \"М\" или \"Ж\"");
                            }

                            Console.Write("Введите рейтинг студента: ");
                            rating = double.Parse(Console.ReadLine());

                            studentManager.AddInfo((int)resultSearch, firstName, lastName, age, rating, gender);
                        }
                        else
                            Console.WriteLine($"Такого ID: {SerchID} не найдено.");
                    }
                    else
                    {
                        Console.Write("Введите имя для поиска: ");
                        firstName = Console.ReadLine();
                        Console.Write("Введите фамилию для поиска: ");
                        lastName = Console.ReadLine();
                        resultSearch = studentManager.SerchStudent(firstName, lastName);
                        if (resultSearch != null)
                        { 
                            Console.Write("Введите имя: ");
                            firstName = Console.ReadLine();
                            Console.Write("Введите фамилию: ");
                            lastName = Console.ReadLine();
                            Console.Write("Введите возраст: ");

                            while (true)
                            {
                                string? input = Console.ReadLine();

                                bool result = int.TryParse(input, out var number);
                                if (result == true && number > 0 && number < 100)
                                {
                                    age = number;
                                    break;
                                }
                                else
                                    Console.WriteLine("Введите коректное значение действия");
                            }
                            Console.Write("Выберите пол(М/Ж): ");

                            while (true)
                            {
                                string? input = Console.ReadLine();
                                if (input == "М")
                                {
                                    gender = input;
                                    break;
                                }
                                else if (input == "Ж")
                                {
                                    gender = input;
                                    break;
                                }
                                else
                                    Console.WriteLine("Введите коректное значение: \"М\" или \"Ж\"");
                            }

                            Console.Write("Введите рейтинг студента: ");
                            rating = double.Parse(Console.ReadLine());

                            studentManager.AddInfo((int)resultSearch, firstName, lastName, age, rating, gender);
                        }
                        else
                            Console.WriteLine($"Студента {firstName} {lastName} не найдено.");
                    }
                    break;
                case 3:
                    
                    Console.WriteLine("Найдите студента, информацию о котором Вы хотите удалить");
                    Console.WriteLine("Выберите режим поиска:\n1 - по ID\n2 - по Имени и Фамилии");
                    while (true)
                    {
                        string? input = Console.ReadLine();

                        bool result1 = int.TryParse(input, out var number);
                        if (result1 == true && number > 0 && number < 3)
                        {
                            options = number;
                            break;
                        }
                        else
                            Console.WriteLine("Введите коректное значение действия");
                    }
                    if (options == 1)
                    {
                        Console.Write("Введите ID для поиска: ");
                        int SerchID = int.Parse(Console.ReadLine());
                        resultSearch = studentManager.IsStudentExists(SerchID);
                        if (resultSearch != 0)
                        {
                            studentManager.DeleteInfo((int)resultSearch);
                        }
                        else
                            Console.WriteLine($"Такого ID: {SerchID} не найдено.");
                    }
                    else
                    {
                        Console.Write("Введите имя для поиска: ");
                        firstName = Console.ReadLine();
                        Console.Write("Введите имя для поиска: ");
                        lastName = Console.ReadLine();
                        resultSearch = studentManager.SerchStudent(firstName, lastName);
                        if (resultSearch != null)
                        {
                            studentManager.DeleteInfo(firstName,lastName);
                        }
                        else
                            Console.WriteLine($"Студента {firstName} {lastName} не найдено.");
                    }
                        break;
                case 4:
                    
                    Console.Write("Введите ID для поиска: ");
                    int ID = int.Parse(Console.ReadLine());
                    resultSearch = studentManager.IsStudentExists(ID);
                    if (resultSearch != null)
                    {
                        var student = studentManager.GetStudent((int)resultSearch);
                        Console.WriteLine("Информация о найденом студенте:");
                        Console.WriteLine($"Имя: {student.FirstName}\n" +
                                $"Фамилия: {student.LastName}\n" +
                                $"Возраст: {student.Age}\n" +
                                $"Пол: {student.Gender}\n" +
                                $"Рейтинг: {student.Rating}\n" +
                                $"ID: {student.ID}\n");
                    }
                    else
                        Console.WriteLine($"Такого ID: {ID} не найдено.");
                    break;
                case 5:
                    Console.Write("Введите имя для поиска: ");
                    firstName = Console.ReadLine();
                    Console.Write("Введите фамилию для поиска: ");
                    lastName = Console.ReadLine();
                    resultSearch = studentManager.SerchStudent(firstName, lastName);
                    if (resultSearch != null)
                    {
                        var student = studentManager.GetStudent((int)resultSearch);
                        Console.WriteLine("Информация о найденом студенте:");
                        Console.WriteLine($"Имя: {student.FirstName}\n" +
                                $"Фамилия: {student.LastName}\n" +
                                $"Возраст: {student.Age}\n" +
                                $"Пол: {student.Gender}\n" +
                                $"Рейтинг: {student.Rating}\n" +
                                $"ID: {student.ID}\n");
                    }
                    else
                        Console.WriteLine($"Студента {firstName} {lastName} не найдено.");
                    break;
                case 6:
                    Console.WriteLine("Информации о всех студентах:");
                    Console.WriteLine("------------------------");
                    int i;
                    var students = studentManager.GetAllStudents();
                    for (i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine($"Имя: {students[i].FirstName}\n" +
                            $"Фамилия: {students[i].LastName}\n" +
                            $"Возраст: {students[i].Age}\n" +
                            $"Пол: {students[i].Gender}\n" +
                            $"Рейтинг: {students[i].Rating}\n" +
                            $"ID: {students[i].ID}\n" +
                            $"------------------------");
                    }
                    Console.WriteLine("Всего студентов: " + i);
                    break;
            }
        }
    }
}