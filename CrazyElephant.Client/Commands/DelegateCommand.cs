using System.Windows.Input;

namespace CrazyElephant.Client.Commands;

public class DelegateCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        // 逻辑：Func==null表示能执行，则短路返回true; Func不为空且则执行，返回执行结果
        return ExecuteFunc == null || ExecuteFunc(parameter);
    }

    public void Execute(object? parameter)
    {
        // 如果没有注册则表示没有action要做
        if(ExecuteAction == null)
            return;

        ExecuteAction(parameter);
    }

    public event EventHandler? CanExecuteChanged;

    public Action<object?>? ExecuteAction { get; set; }
    public Func<object?, bool>? ExecuteFunc { get; set; }
}