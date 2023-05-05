namespace StudentManagerLibrary
{
    public class StudentManager : IBackUp
    {
        private int counterIdStudent = 1;

        private List<Student> students;

        private readonly Stack<List<Student>> backUp;

        public StudentManager()
        {
            students = new List<Student>();

            backUp = new Stack<List<Student>>();
        }

        /// <summary>
        /// Добавление в журнал нового студента
        /// </summary>
        /// <param name="name">имя студента</param>
        /// <param name="age">возраст студента</param>
        /// <param name="gender">пол студента</param>
        /// <param name="grade">оценка студента</param>
        /// <returns>Возвращает string с информацией о результате выполнения операции.</returns>
        public string AddStudent(string name, byte age, char gender, byte grade)
        {
            BackUp();
            Student student = new Student(counterIdStudent, name, age, gender, grade);
            students.Add(student);
            counterIdStudent++;
            return $"Студент {name} успешно добавлен.\n";
        }

        /// <summary>
        /// Редактирование путем передачи в качестве параметра измененного объекта. Внутри метода поиск по ID и замена ссылки на переданный объект.
        /// </summary>
        /// <param name="EditedStudent">Передаем измененный объект</param>
        /// <returns>Возвращает string с информацией о результате выполнения операции.</returns>
        public string EditStudent(Student EditedStudent)
        {
            int index = students.FindIndex(st => st.Id == EditedStudent.Id);
            if (index != -1)
            {
                BackUp();
                students[index] = EditedStudent;
                return $"Студент c ID {EditedStudent.Id} успешно изменен.\n";
            }
            return $"Студент c ID {EditedStudent.Id} не найден!\n";
        }

        /// <summary>
        /// Удаление студента по ID
        /// </summary>
        /// <param name="studentID">ID студента</param>
        /// <returns>Возвращает string с информацией о результате выполнения операции.</returns>
        public string RemoveStudent(int studentID)
        {
            var student = students.FirstOrDefault(student => student.Id == studentID);
            if (students.Remove(student))
            {
                BackUp();
                return $"Студент c ID {studentID} удален!\n";
            }
            return $"Студент c ID {studentID} не найден!\n";
        }

        /// <summary>
        /// Поиск студента по имени. 
        /// </summary>
        /// <param name="name">Критерий поиска</param>
        /// <returns>Возвращает копию обьекта при успехе иначе null</returns>
        public Student SearchByName(string name)
        {
            var student = students.FirstOrDefault(student => student.Name == name);
            if (student != null)
                return new Student(student.Id, student.Name, student.Age, student.Gender, student.Grade);
            return null;
        }

        /// <summary>
        /// Поиск студента по ID студента. 
        /// </summary>
        /// <param name="ID">Критерий поиска</param>
        /// <returns>Возвращает копию обьекта при успехе иначе null</returns>
        public Student SearchByID(int ID)
        {
            var student = students.FirstOrDefault(student => student.Id == ID);
            if (student != null)
                return new Student(student.Id, student.Name, student.Age, student.Gender, student.Grade);
            return null;
        }
        /// <summary>
        /// Возвращает копию списока студентов 
        /// </summary>
        /// <returns>Возвращает копию списока студентов </returns>
        public List<Student> GetStudents()
        {
            return students.Select(s => new Student(s.Id, s.Name, s.Age, s.Gender, s.Grade)).ToList();
        }
        /// <summary>
        /// Записывает текущее состояние журнала студентов в стэк.  
        /// </summary>
        public void BackUp()
        {
            backUp.Push(GetStudents());
        }
        /// <summary>
        /// Возвращает послед. записанное состояние журнала студентов из стэка.   
        /// </summary>
        /// <returns>Возвращает bool если попытка успешная, иначе false. </returns>
        public bool RollBack()
        {
            if (backUp.Count > 0)
            {
                students = backUp.Pop();
                return true;
            }
            return false;
        }
    }
}
