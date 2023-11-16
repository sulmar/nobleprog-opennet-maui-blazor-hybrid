using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiClient.Core;

class RelayCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private readonly Action execute;
    private readonly Func<bool> canExecute;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return canExecute ?.Invoke() ?? true;
    }

    public void Execute(object parameter)
    {
        execute?.Invoke();
    }
}
