using System.Windows.Input;

namespace WPF_MVVM.Commands;

// 命令是在使用MVVM时，将原来的事件给单独分离出来
public class DelegateCommand:ICommand
{
    // 判断该命令能不能执行
    public bool CanExecute(object? parameter)
    {

        // 如果没有检查方法，就直接返回true
        if (CanExecuteFunc == null) return true;
        return CanExecuteFunc(parameter); 
    }
    
    // 在命令执行之后可以通知调用者
    public event EventHandler? CanExecuteChanged;


    public void Execute(object? parameter)
    {
        if(ExecuteAction == null)
            return;
        // 将Execute要执行的命令委托给ExecuteAction这个委托
        ExecuteAction(parameter);
    }


    // 这是一个实现了ICommand的Command基类，所有需要使用命令的对象都要继承自该类，
    // 那么就能使用下面两个委托来添加方法，然后在上面CanExecute和Execute内部执行
    public Action<Object?>? ExecuteAction { get; set; }
    public Func<Object?,bool>? CanExecuteFunc { get; set; }

}