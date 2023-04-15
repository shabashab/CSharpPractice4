using System;
using System.Windows.Input;

namespace CSharpPractice3.Helpers
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) 
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public void InvokeCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, null);
        }

        public bool CanExecute(object? parameter)
        {
            if (this.canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
