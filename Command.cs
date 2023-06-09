﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace MVVMENTITY
{
    // команды - альтернатива ивентам и лучше использовать их - будет меньше бардака    
    internal sealed class Command : ICommand
    {
       
        private Action<object> execute;
        private Func<object, bool> canExecute;
        // команда добавление / удаление обьекта
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        // проверка на изменение обьекта, существует он или нет
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

}
