namespace CrazyElephant.Client.Services;

public interface IOrderService
{
    // 定义处理订单方法的接口
    void PlaceOrder(List<string> dishes);
}