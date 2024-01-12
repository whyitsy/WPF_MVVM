using CrazyElephant.Client.Models;

namespace CrazyElephant.Client.Services;

// 定义处理不同数据来源的接口
// 不同场景下数据来源不同，XML、txt、Excel、数据库等，
public interface IDataService
{
    List<Dish> GetDishList();
}