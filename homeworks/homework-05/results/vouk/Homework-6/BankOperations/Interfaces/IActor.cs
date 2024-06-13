namespace BankOperations.Interfaces
{
    public interface IActor
    {
        bool IsClient();
        bool IsInsurer();
    }
}