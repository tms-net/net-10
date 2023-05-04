internal partial class Program
{
    interface IStudentManager
    {
        /// <summary>
        /// Добавление информации о новом студенте
        /// </summary>
        /// <param name="student">Ссылка на объект типа Students, в который будет добавлена информация</param>
        /// <param name="firstName">Имя студента</param>
        /// <param name="lastName">Фамилия студента</param>
        /// <param name="age">Возраст в годах</param>
        /// <param name="rating">Рейтинг студента</param>
        /// <param name="gender">Пол студента</param>
        void AddInfo(Student student, string firstName, string lastName, int age, double rating, string gender); //Добавление информации о новых студентах
        /// <summary>
        /// Удаление информации о студенте
        /// </summary>
        /// <param name="student">Ссылка на колекцию типа Students, из которой будет удален студент</param>
        /// <param name="SerchID">ID удоляемого студента</param>
        void DeleteInfo(List<Student> student, int SerchID); //Удаление информации о студенте
        /// <summary>
        /// Удаление информации о студенте
        /// </summary>
        /// <param name="student">Ссылка на колекцию типа Students, из которой будет удален студент</param>
        /// <param name="firstName">Имя удаляемого студента</param>
        /// <param name="lastName">Фамилия удаляемого студента</param>
        void DeleteInfo(List<Student> student, string firstName, string lastName); //Удаление информации о студенте
    }
 
}