﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace 密码本.ViewModel
{
    public class DelegateCommand:ICommand
    {
        readonly Action<object> _execute;

        readonly Predicate<object> _canExecute;



        public DelegateCommand(Action<object> execute)

            : this(execute, null)

        {

        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)

        {

            if (execute == null)

                throw new ArgumentNullException("execute");

            _execute = execute;

            _canExecute = canExecute;

        }

        public void Execute(object parameter)

        {

            _execute(parameter);

        }

        public bool CanExecute(object parameter)

        {

            return _canExecute == null ? true : _canExecute(parameter);

        }

        public event EventHandler CanExecuteChanged

        {

            add { CommandManager.RequerySuggested += value; }

            remove { CommandManager.RequerySuggested -= value; }

        }
    }
}
