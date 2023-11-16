using MauiClient.Core;
using MauiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiClient.ViewModel;

internal class CounterViewModel
{
    public CounterState CounterState { get; set; } = new();

    public ICommand IncrementCounterCommand { get; set; }

    public CounterViewModel()
    {
        CounterState.Count = 10;

        IncrementCounterCommand = new RelayCommand(IncrementCounter);
    }

    private void IncrementCounter()
    {
        CounterState.Count++;
    }
}
