namespace CrazyElephant.Client.Models;


// 对菜品进行建模
public class Dish
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public double Score { get; set; }


}