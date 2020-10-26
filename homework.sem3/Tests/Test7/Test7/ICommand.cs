using System;

namespace Test7
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }
}
