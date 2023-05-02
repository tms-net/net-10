using StudentManagerLibrary;

namespace Patapau

{
    internal class Program
    {

        static void Main()
        {
            StudentManager studentManager = new StudentManager();
            studentManager.AddStudent("Дима", 15, 'М', 9);
            studentManager.AddStudent("Настя", 15, 'Ж', 10);


            bool isRunning = true;
            string nameConsole;
            char genderConsole;
            byte ageConsole, gradeConsole;
            int idConsole;
            Student student;
            Console.WriteLine("Добро пожаловать в программу StudentManager.");
            while (isRunning)
            {
                Console.WriteLine("Выберите доступное действие:\n" +
                    " 1 - Добавить студента\n" +
                    " 2 - Редактировать студента\n" +
                    " 3 - Удалить студента\n" +
                    " 4 - Поиск студента по ID\n" +
                    " 5 - Поиск студента по имени\n" +
                    " 6 - Список студентов\n" +
                    " 7 - Завершение работы.\n");
                var operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        Console.Clear();
                        EnterDataStudent();
                        studentManager.AddStudent(nameConsole, ageConsole, genderConsole, gradeConsole);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Введите ID студента для редактирования");
                        EnterStudentID();
                        if (studentManager.CheckIdStudentExistence(idConsole))
                        {
                            EnterDataStudent();
                            studentManager.EditStudent(idConsole, nameConsole, ageConsole, genderConsole, gradeConsole);
                        }
                        else
                        {
                            Console.WriteLine("Не найдено совпадений в БД!\n");
                        }
                        break;
                   
                    
                    
                    
                    
                    
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Введите ID студента для удаления");
                        EnterStudentID();
                        studentManager.RemoveStudent(idConsole);
                        break;
                    
                    
                    
                    
                    
                    
                    
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Введите ID студента для поиска");
                        EnterStudentID();
                        student = studentManager.SearchByID(idConsole);
                        if (student == null)
                            Console.WriteLine("Не найдено совпадений в БД!\n");
                        Console.WriteLine(student);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Введите имя студента для поиска");
                        student = studentManager.SearchByName(Console.ReadLine());
                        if (student == null)
                            Console.WriteLine("Не найдено совпадений в БД!\n");
                        Console.WriteLine(student);
                        break;
                    case "6":
                        Console.Clear();
                        var students = studentManager.GetStudents();
                        if (students.Count == 0)
                            Console.WriteLine("Нет студентов в БД! Необходимо добавить студентов!\n");
                        foreach (var stud in students)
                        {
                            Console.WriteLine(stud);
                        }
                        break;
                    case "7":
                        Console.Clear();
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неизвестная команда! Повторите попытку!\n");
                        break;
                }
            }








            // Ввод данных студента в консоль (nameConsole, ageConsole, genderConsole, gradeConsole)
            void EnterDataStudent()
            {
                Console.WriteLine("Введите имя студента");
                nameConsole = Console.ReadLine();
                Console.WriteLine("Введите возраст студента");
                while (!byte.TryParse(Console.ReadLine(), out ageConsole))
                {
                    Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода возраста студента!");
                }
                Console.WriteLine("Введите пол студента М или Ж");
                while (!char.TryParse(Console.ReadLine(), out genderConsole) || (genderConsole != 'Ж' && genderConsole != 'М'))
                {
                    Console.WriteLine("Некорректный ввод, попробуйте снова:");
                }
                Console.WriteLine("Введите оценку");
                while (!byte.TryParse(Console.ReadLine(), out gradeConsole))
                {
                    Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода возраста студента!");
                }
            }
            //Ввод ID студента
            void EnterStudentID()
            {
                while (!int.TryParse(Console.ReadLine(), out idConsole))
                {
                    Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода ID студента!");
                }

            }





        }



    }
}