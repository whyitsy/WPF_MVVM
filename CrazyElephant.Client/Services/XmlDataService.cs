using System.Xml.Linq;
using CrazyElephant.Client.Models;

namespace CrazyElephant.Client.Services;

/// <summary>
/// 将XML数据转为 List<Dish>，好像序列化操作能更简单方便，后续完善一下
/// </summary>
public class XmlDataService:IDataService
{
    public List<Dish> GetDishList()
    {
        List<Dish> dishList = new List<Dish>();

        string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
        XDocument xDoc = XDocument.Load(xmlFileName);

        var dishes = xDoc.Descendants("Dish");

        foreach (var d in dishes)
        {
            Dish dish = new Dish()
            {
                Name = d.Element("Name").Value,
                Category = d.Element("Category").Value,
                Comment = d.Element("Comment").Value,
                Score = double.Parse(d.Element("Score").Value)
            };
            dishList.Add(dish);
        }

        return dishList;
    }
}