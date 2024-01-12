using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM.ViewModels;

public class ObservableObject:INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // 使用[CallerMemberName]特性可以简化程序
    protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        RaisePropertyChanged(propertyName);
        return true;
    }   
}