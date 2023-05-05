using StudentManagerLibrary;

namespace Patapau

{
    internal class Program
    {

        static void Main()
        {
            StudentManager studentManager = new StudentManager();
            studentManager.AddStudent("1", 1, 'М', 1);
            //studentManager.RemoveStudent(1);
            //var st = studentManager.GetStudents();
            //Console.WriteLine(st.Count);
            //studentManager.RollBack();
            //var st1 = studentManager.GetStudents();
            //Console.WriteLine(st1.Count);


            bool isRunning = true;

            string nameConsole;
            char genderConsole;
            byte ageConsole, gradeConsole;
            int idConsole;

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
                    " 7 - Сделать отмену изменений в журнале студентов\n" +
                    " 8 - Завершение работы.\n");
                var operation = Console.ReadLine();
                switch (operation)
                {

                    case "1":
                        Console.Clear();
                        EnterDataStudent();
                        Console.WriteLine(studentManager.AddStudent(nameConsole, ageConsole, genderConsole, gradeConsole));
                        break;


                    case "2":
                        Console.Clear();
                        var students = studentManager.GetStudents();
                        if (students.Count == 0)
                        {
                            Console.WriteLine("Нет студентов в БД! Необходимо добавить студентов!\n");
                            break;
                        }

                        foreach (var stud in students)
                        {
                            Console.WriteLine(stud);
                        }
                        Console.WriteLine("Введите ID студента для редактирования");
                        EnterStudentID();
                        var student = students.FirstOrDefault(s => s.Id == idConsole);
                        if (student != null)
                        {
                            Console.WriteLine($"Выбранный студент для редактирования\n {student}");
                            EnterDataStudent();
                            student.Name = nameConsole;
                            student.Gender = genderConsole;
                            student.Age = ageConsole;
                            student.Grade = gradeConsole;
                            Console.WriteLine(studentManager.EditStudent(student));
                        }
                        else
                        {
                            Console.WriteLine("Не найдено совпадений в БД!\n");
                        }
                        break;


                    case "3":
                        Console.Clear();
                        students = studentManager.GetStudents();
                        if (students.Count == 0)
                        {
                            Console.WriteLine("Нет студентов в БД! Необходимо добавить студентов!\n");
                            break;
                        }
                        foreach (var stud in students)
                        {
                            Console.WriteLine(stud);
                        }
                        Console.WriteLine("Введите ID студента для удаления");
                        EnterStudentID();
                        Console.WriteLine(studentManager.RemoveStudent(idConsole));
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
                        students = studentManager.GetStudents();
                        if (students.Count == 0)
                            Console.WriteLine("Нет студентов в БД! Необходимо добавить студентов!\n");
                        foreach (var stud in students)
                        {
                            Console.WriteLine(stud);
                        }
                        break;


                    case "7":
                        Console.Clear();
                        if (studentManager.RollBack())
                            Console.WriteLine("Откат изменений успешно выполнен!");
                        else
                            Console.WriteLine("Журнал студентов находится в первоначальном состоянии. Отменить изменения невозможно.");
                        break;


                    case "8":
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
                    Console.WriteLine("Некорректный ввод, попробуйте снова. Введите пол студента М или Ж");
                }
                Console.WriteLine("Введите оценку");
                while (!byte.TryParse(Console.ReadLine(), out gradeConsole))
                {
                    Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода возраста студента!");
                }
            }
            //Ввод ID студента(idConsole)
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