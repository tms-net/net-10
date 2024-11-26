internal partial class Program
{
    internal class Student
    {
        public Student()
        {
            ID = rnd.Next(0, 20001);
        }
        Random rnd = new Random();
        public string FirstName { get; set; } //Имя
        public string LastName { get; set; } //Фамилия
        public int Age { get; set; } //Возраст
        public double Rating { get; set; } //Оценка
        public string Gender { get; set; } //Пол 
        public int ID { get; } //Идентификатор

        
    }
    
}