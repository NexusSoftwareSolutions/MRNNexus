﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRNNexus.WPFClient.ViewModels
{
    class RelayCommand : ICommand
    {
        private Action<object> _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> action)
        {
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            {
                _action(parameter);
            }
            else
            {
                _action(null);
            }
        }

    }
}
