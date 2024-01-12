namespace CrazyElephant.Client.Services;

public class MockOrderService:IOrderService
{
    // 模拟订单处理
    public void PlaceOrder(List<string> dishes)
    {
        // 这里就简单的将订单存储到本地，后续可以将其存储到数据库
        System.IO.File.WriteAllLines(@"./order.txt", dishes);

    }
}