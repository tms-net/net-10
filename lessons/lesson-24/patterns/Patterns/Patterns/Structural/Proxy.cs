namespace TradingApp.Patterns
{
    public interface IRequestHandler
    {
        string HandleRequest(string request);
    }

    public class GoogleHandler : IRequestHandler
    {
        public string HandleRequest(string request)
        {
            return "Google";
        }
    }

    public class CachedProxyHandler : IRequestHandler
    {
        IRequestHandler _originalHandler;
        Dictionary<string, string> _cache;

        public CachedProxyHandler(IRequestHandler originalHandler)
        {
            _originalHandler = originalHandler;
        }

        public string HandleRequest(string request)
        {
            if (_cache.TryGetValue(request, out var response))
            {
                return response;
            }

            response = _originalHandler.HandleRequest(request);
            _cache.Add(request, response);
            return response;
        }
    }



    // PROXY

    // Основная задача
    //   объект, реализуюзий интерфейс

    // Ответственность прокси компонента

    // браузер -> ЗАПРОС в ГУГЛ -> РАБОТА НА СЕРВЕРЕ -> ПОЛУЧИТЬ ОТВЕТ // HTTP

    // браузер -> ЗАПРОС в ПРОКСИ СЕРВЕР -> РАБОТА НА ПРОКСИ СЕРВЕРЕ -> РАБОТА НА СЕРВЕРЕ -> ПОЛУЧИТЬ ОТВЕТ -> ПОЛУЧИТЬ ОТВЕТ ОТ ПРОКСИ

    // ОТВЕТ DoJob(ЗАПРОС)

    // 1.
    // Если много запросов

    // ОТВЕТ DoJob(ЗАПРОС) -> если запрос был обработан то вернуть результат

    // 2.
    // Проверить запрос 
    // если запрещенный сайт -> прервать запрос

    // 3.
    // Доплонить запрос 
}
