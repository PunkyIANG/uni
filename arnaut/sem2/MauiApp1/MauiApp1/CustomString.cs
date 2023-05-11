﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1;

public struct CustomString : INotifyPropertyChanged
{
    public string Value;
    
    public CustomString(string value)
    {
        Value = value;
    }
    
    public override string ToString()
    {
        return Value;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}