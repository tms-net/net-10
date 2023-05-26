namespace patapau.Task2
{
    public class LogHistory : ILogs
    {
        protected List<Log> logs = new List<Log>();
        public void AddLog(string messageLog, string categoryLog, double balance)
        {
            logs.Add(new Log(DateTime.Now, messageLog, categoryLog, balance));
        }
        public List<Log> GetFullHistoryLog()//Возвращает историю логов
        {
            return logs;
        }
    }

}
