using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Navigator.Commands
{
    public class DelegateCommand : ICommand
    {
        //public event EventHandler CanExecuteChanged;

        //public bool CanExecute(object parameter)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Execute(object parameter)
        //{
        //    throw new NotImplementedException();
        //}
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        private Action onSearch;
        private Func<bool> canSerch;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute,
                               Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action onSearch, Func<bool> canSerch)
        {
            this.onSearch = onSearch;
            this.canSerch = canSerch;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

}

