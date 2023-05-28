internal partial class Program
{
    interface IStudentManager
    {
        /// <summary>
        /// Добавление информации о новом студенте
        /// </summary>
        /// <param name="firstName">Имя студента</param>
        /// <param name="lastName">Фамилия студента</param>
        /// <param name="age">Возраст в годах</param>
        /// <param name="rating">Рейтинг студента</param>
        /// <param name="gender">Пол студента</param>
        void AddInfo( string firstName, string lastName, int age, double rating, string gender); //Добавление информации о новых студентах
        /// <summary>
        /// Удаление информации о студенте
        /// </summary>
        /// <param name="SerchID">ID удоляемого студента</param>
        void DeleteInfo( int SerchID); //Удаление информации о студенте
        /// <summary>
        /// Удаление информации о студенте
        /// </summary>
        /// <param name="firstName">Имя удаляемого студента</param>
        /// <param name="lastName">Фамилия удаляемого студента</param>
        void DeleteInfo( string firstName, string lastName); //Удаление информации о студенте
    }
 
}