using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test7
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// event handler for canExecute change
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// relay command constructor
        /// </summary>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// if method can be executed
        /// </summary>
        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter);

        /// <summary>
        /// execute method command
        /// </summary>
        public void Execute(object parameter) => this.execute(parameter);
    }
}
