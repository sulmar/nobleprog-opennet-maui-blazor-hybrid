﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiClient.Model;


public abstract class Base : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class CounterState : Base
{
    private int count;

    public int Count
    {
        get => count;
        set
        {
            count = value;
            OnPropertyChanged("Count");
        }
    }
}
