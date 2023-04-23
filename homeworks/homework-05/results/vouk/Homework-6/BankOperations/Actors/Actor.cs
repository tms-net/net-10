using BankOperations.Interfaces;

namespace BankOperations.Actors
{
    public abstract class Actor : IActor
    {
        public bool IsActorClient { get; }

        protected Actor(bool isActorClient)
        {
            IsActorClient = isActorClient;
        }

        public bool IsClient() => IsActorClient;

        public bool IsInsurer() => !IsActorClient;
    }
}