using System;
using System.Windows.Input;

namespace Chess_GUI.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        // Main constructor
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new NullReferenceException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        // Constructor used if no info about can execute is passed
        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }


        public bool CanExecute(object parameter)
        {
            return true;
            //return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
