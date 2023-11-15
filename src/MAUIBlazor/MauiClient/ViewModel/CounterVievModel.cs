using MauiClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiClient.ViewModel;

internal class CounterViewModel
{
    public CounterState CounterState { get; set; } = new();

    public CounterViewModel()
    {
        CounterState.Count = 10;
    }

    private void IncrementCounter()
    {
        CounterState.Count++;
    }
}
