using System;
namespace Homework_8
{
	public class CommandManager
	{
		//contains stack of commands
		private Stack<ICommand> _commandHistory;

		public CommandManager()
		{
			_commandHistory = new Stack<ICommand>();
		}

		public void CallCommand(ICommand newCommand)
		{
			newCommand.Do();
			_commandHistory.Push(newCommand);
		}

		public void UndoCommand()
		{
			if(_commandHistory.Count > 0)
			{
                var deniedCommand = _commandHistory.Pop();
                deniedCommand.Undo();
            }
        }
	}
}

