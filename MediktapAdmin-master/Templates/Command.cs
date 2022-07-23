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
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
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

    public class Command<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        /// <summary>
        /// Constructor not using canExecute.
        /// </summary>
        /// <param name="execute"></param>
        public Command(Action<T> execute) : this(execute, null) { }

        /// <summary>
        /// Constructor using both execute and canExecute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// This method is called from XAML to evaluate if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        /// <summary>
        /// This method is called from XAML to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        /// <summary>
        /// This method allow us to force the execution of CanExecute method to reevaluate execution.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// This event notify XAML controls using the command to reevaluate the CanExecute of it.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}