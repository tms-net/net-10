namespace patapau.Task2
{
    //Класс для логов операций
    public class Log
    {
        public DateTime Date { get; }// Дата лога
        public string Message { get; }// Описание события 
        public string Category { get; }// Тип события (Перевод, Пополнение, Ошибка, Вывод)
        public double Balance { get; }// Баланс после операции
        public Log(DateTime date, string message, string category, double balance)
        {
            Date = date;
            Message = message;
            Category = category;
            Balance = balance;
        }
        public string GetLog()
        {
            return $"Log: Дата - {Date} Категория - {Category} \nСообщение - {Message} \nТекущий баланс - {Balance}\n-----------------------------------------------------------";
        }
    }
}
