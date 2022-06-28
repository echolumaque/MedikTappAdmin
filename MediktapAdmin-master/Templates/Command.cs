using System;
using System.Windows.Input;

namespace MediktapAdmin.Templates
{
    public class Command : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public Command(Action action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}