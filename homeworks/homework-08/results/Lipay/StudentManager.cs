internal partial class Program
{
    internal class StudentManager 
    {
        public StudentManager()
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
        public void AddInfo(string firstName, string lastName, int age, double rating, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Rating = rating;
        }

        public void DeleteInfo()
        {
            throw new NotImplementedException();
        }

        public void PrintInfoFromID()
        {
            throw new NotImplementedException();
        }

        public void PrintInfoFromName()
        {
           // StudentManager result = List<>.Find(item => item.FirstName == "Anton");
        }

        public void RefreshInfo()
        {
            throw new NotImplementedException();
        }
    }
}