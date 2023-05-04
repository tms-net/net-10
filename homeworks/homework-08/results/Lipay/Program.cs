using System;
using System.Reflection;

internal partial class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Программа: Менеджер студентов");

        List<Student> students = new List<Student>();
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
                    students.Add(new Student());

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

     
                    studentManager.AddInfo(students[students.Count - 1],firstName, lastName, age, rating, gender);

                    break;
                case 2:
                    int resultSearch;
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
                        if (students.Exists(x => x.ID == SerchID))
                        {
                            resultSearch = students.FindIndex(x => x.ID == SerchID);
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

                            studentManager.AddInfo(students[resultSearch], firstName, lastName, age, rating, gender);
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
                        if (students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
                        {
                            resultSearch = students.FindIndex(x => x.FirstName == firstName && x.LastName == lastName);
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

                            studentManager.AddInfo(students[resultSearch], firstName, lastName, age, rating, gender);
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
                        if (students.Exists(x => x.ID == SerchID))
                        {
                            studentManager.DeleteInfo(students, SerchID);
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
                        if (students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
                        {
                            studentManager.DeleteInfo(students, firstName,lastName);
                        }
                        else
                            Console.WriteLine($"Студента {firstName} {lastName} не найдено.");
                    }
                        break;
                case 4:
                    Console.Write("Введите ID для поиска: ");
                    int ID = int.Parse(Console.ReadLine());
                    if (students.Exists(x => x.ID == ID))
                    {
                        int resultID = students.FindIndex(x => x.ID == ID);
                        Console.WriteLine("Информация о найденом студенте:");
                        Console.WriteLine($"Имя: {students[resultID].FirstName}\n" +
                                $"Фамилия: {students[resultID].LastName}\n" +
                                $"Возраст: {students[resultID].Age}\n" +
                                $"Пол: {students[resultID].Gender}\n" +
                                $"Рейтинг: {students[resultID].Rating}\n" +
                                $"ID: {students[resultID].ID}\n");
                    }
                    else
                        Console.WriteLine($"Такого ID: {ID} не найдено.");
                    break;
                case 5:
                    Console.Write("Введите имя для поиска: ");
                    string? SearchFirstName = Console.ReadLine();
                    Console.Write("Введите фамилию для поиска: ");
                    string? SearchLastName = Console.ReadLine();
                    if (students.Exists(x => x.FirstName == SearchFirstName && x.LastName == SearchLastName))
                    {
                        int resultName = students.FindIndex(x => x.FirstName == SearchFirstName && x.LastName == SearchLastName);

                        Console.WriteLine("Информация о найденом студенте:");
                        Console.WriteLine($"Имя: {students[resultName].FirstName}\n" +
                                $"Фамилия: {students[resultName].LastName}\n" +
                                $"Возраст: {students[resultName].Age}\n" +
                                $"Пол: {students[resultName].Gender}\n" +
                                $"Рейтинг: {students[resultName].Rating}\n" +
                                $"ID: {students[resultName].ID}\n");
                    }
                    else
                        Console.WriteLine($"Студента {SearchFirstName} {SearchLastName} не найдено.");
                    break;
                case 6:
                    Console.WriteLine("Информации о всех студентах:");
                    Console.WriteLine("------------------------");
                    int i;
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