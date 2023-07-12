namespace Patterns.Behavioral
{
    internal interface ICommand
    {
        void Do();

        // void Undo();
    }

    public class SaveArguments
    {
    }

    public class SaveCommand : ICommand
    {
        public SaveCommand(Manager mgr, SaveArguments args)
        {
        }

        public void Do()
        {
            // Do Manager action with args
        }

        void Undo() 
        {
            // Undo manager action woth args
        }
    }
}
