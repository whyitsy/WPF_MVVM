using Microsoft.Win32;
using WPF_MVVM.Commands;

namespace WPF_MVVM.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    // 三个数据属性，两个命令属性=>加法器

    private double input1;

    public double Input1
    {
        get => input1;
        set
        {
            if (SetField(ref input1, value))
                RaisePropertyChanged();
        }
    }

    private double input2;

    public double Input2
    {
        get => input2;
        set
        {
            if (SetField(ref input2,value))
                RaisePropertyChanged();
        }
    }

    private double result;

    public double Result
    {
        get => result;
        set
        {
            if(SetField(ref result, value))
                RaisePropertyChanged();
        }
    }

    // Add命令
    public DelegateCommand AddCommand { get; set; }

    private void Add(object? parameter)
    {
        Result = Input1 + Input2;
    }

    // Save命令
    public DelegateCommand SaveCommand { get; set; }

    private void Save(object? parameter)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.ShowDialog();
    }

    public MainWindowViewModel()
    {
        // 在构造函数中将Add方法和AddCommand关联起来
        AddCommand = new DelegateCommand() {ExecuteAction = Add};

        // 同理管理Save命令
        SaveCommand = new DelegateCommand() {  ExecuteAction = Save};
    }
}