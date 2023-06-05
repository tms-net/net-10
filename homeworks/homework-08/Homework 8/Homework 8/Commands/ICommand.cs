using System;
namespace Homework_8
{
	public interface ICommand
	{
		public void Do();
		public void Undo();
	}
}

