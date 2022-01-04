using System;
using System.Windows.Input;

namespace ContactBook.WPF.Command
{
    public class RelayCommand : ICommand
    {
        Action TargetExecuteMethod;
        Func<bool> TargetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executedMethod, Func<bool> canExecuteMethod)
        {
            TargetExecuteMethod = executedMethod;
            TargetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChange()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (TargetCanExecuteMethod != null)
            {
                return TargetCanExecuteMethod();
            }
            if (TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (TargetExecuteMethod != null)
            {
                TargetExecuteMethod();
            }
        }
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> TargetExecuteMethod;
        Func<T, bool> TargetCanExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMthod, Func<T, bool> canExecuteMethod)
        {
            TargetExecuteMethod = executeMthod;
            TargetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (TargetCanExecuteMethod != null)
            {
                return TargetCanExecuteMethod((T)parameter);
            }

            if (TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (TargetExecuteMethod != null)
            {
                TargetExecuteMethod((T)parameter);
            }
        }
    }
}
