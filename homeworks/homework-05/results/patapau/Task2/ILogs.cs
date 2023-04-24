namespace patapau.Task2
{
    public interface ILogs
    {
        void AddLog(string messageLog, string categoryLog, double balance);// Добавить лог в историю
        List<Log> GetFullHistoryLog();// Загрузка полной истории логов
    }
}
