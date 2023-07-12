using System.Text;

namespace Patterns
{
    // SOLID - D = Dependency Inversion
    // Inversion of Control / Dependency Injection
    // 

    public class Singleton
    {
        static Singleton _instance;

        // public static Singleton Instance() => _instance ??= new Singleton(Service1.Instance, new Service2());

        private Singleton(IService1 service1, IService2 service2)
        {
        }
    }

    // ThreadPool

    public abstract class ServiceFactory
    {
        public virtual void Initialize()
        {
            // init 

            var builder = new StringBuilder();

            builder.Append("");
            builder.AppendFormat("", "");


            builder.ToString();// Create(), Build()
        }

        public abstract IService CreateService();
    }

    public class RemoteServiceFactory : ServiceFactory
    {

        public override virtual IService CreateService()
        {
            return new RemoteService();
        }
    }

    public class LocalServiceFactory : ServiceFactory
    {
        public override virtual IService CreateService()
        {
            return new LocalService();
        }
    }

    // IoC Containers - Singleton OK
}
