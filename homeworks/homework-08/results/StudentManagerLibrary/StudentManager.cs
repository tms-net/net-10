namespace StudentManagerLibrary
{
    public class StudentManager
    {
        private int counterIdStudent = 1;

        private readonly List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(string name, byte age, char gender, byte grade)
        {
            Student student = new Student(counterIdStudent, name, age, gender, grade);
            students.Add(student);
            counterIdStudent++;
        }

        public void EditStudent(int id, string name, byte age, char gender, byte grade)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            student.Name = name;
            student.Age = age;
            student.Gender = gender;
            student.Grade = grade;
        }

        /// <summary>
        /// Удаление студента по ID
        /// </summary>
        /// <param name="studentID">ID студента</param>
        /// <returns>При успешном удалении возвращается true, иначе false.</returns>
        public void RemoveStudent(int studentID)
        {
            var student = students.FirstOrDefault(student => student.Id == studentID);
            if (student != null)
            {
                students.Remove(student);
            }
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
            List<Student> CopyList = new List<Student>();
            foreach( var student in students)
                CopyList.Add(new Student(student.Id, student.Name, student.Age, student.Gender, student.Grade));
            return CopyList;
        }
        public bool CheckIdStudentExistence(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return student != null;
        }

    }
}
