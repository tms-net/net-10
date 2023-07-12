namespace Patterns.Behavioral
{
    public class Context
    {
    }

    internal interface IModule
    {
        void Process(Context context, IModule next);
    }

    internal class ExceptionModule : IModule
    {
        // Требует идентификации пользователя
        public void Process(Context context, Action next)
        {
            // логика до продолжения цепочки
            
            try
            {
                // продолжение цепочки

                next.Process(context, /**/);

                // Есть результат после полного выполнения цепочки
            }
            catch            
            {
                // после выполнения цепочки
            }
        }
    }

    internal class UserModule : IModule
    {
        // Требует идентификации пользователя
        public void Process(Context context, Action next)
        {
            // Получить пользователя из контекста

            // Если ОК

            next();

            // Если нет пользователя


            // throw new InvalidOperationException();
        }
    }

    internal class Pipeline
    {
        IModule[] _modules;

        public Pipeline(IModule[] modules)
        {
            _modules = modules;
        }

        public void Run(Context context)
        {
            foreach (var module in _modules)
            {
                try
                {
                    module.Process(context);
                }
                catch
                {
                }

                // Как прервать выполнение?
                // 
            }
        }
    }
}
