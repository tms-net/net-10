internal partial class Program
{
    interface IStufentManager
    {
        //void AddInfo(); //Добавление информации о новых студентах
        void RefreshInfo(); //Обновление информации о студенте
        void DeleteInfo(); //Удаление информации о студенте
        void PrintInfoFromID(); //Получение информации о студенте по идентификатору
        void PrintInfoFromName(); //Получение информации о студенте по фамилии/имени
    }
 
}