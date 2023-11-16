using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiClient.Core;
using MauiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiClient.ViewModel;

public abstract class BaseViewModel : ObservableObject
{

}

public partial class CounterViewModel : BaseViewModel
{
    [ObservableProperty]
    private CounterState counterState = new();

    public CounterViewModel()
    {
        CounterState.Count = 10;
    }

    [RelayCommand(CanExecute = nameof(CanIncrementCounter))]
    private void IncrementCounter()
    {
        CounterState.Count++;

        IncrementCounterCommand.NotifyCanExecuteChanged();
    }

    bool CanIncrementCounter() => CounterState.Count < 20;
}
