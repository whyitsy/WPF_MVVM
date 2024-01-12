using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using CrazyElephant.Client.Commands;
using CrazyElephant.Client.Models;
using CrazyElephant.Client.Services;

namespace CrazyElephant.Client.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public DelegateCommand PlaceOrderCommand { get; set; }
    public DelegateCommand SelectMenuItemCommand { get; set; }

    // 统计选择个菜品种类数
    private int itemsCount;

    public int ItemsCount
    {
        get => itemsCount;
        set
        {
            if (SetField(ref itemsCount, value))
                RaisePropertyChanged();
        }
    }

  
    private Restaurant restaurant;

    public Restaurant Restaurant
    {
        get => restaurant;
        set
        {
            if (SetField(ref restaurant, value))
                RaisePropertyChanged();
        }
    }

    // public ObservableCollection<MenuDishItemViewModel> Type { get; set; }
    // 这里的set是否是多余的,因为只有在初始化时才会在构造函数中调用LoadDishMenu更新DishMenu
    private List<MenuDishItemViewModel> dishMenu;

    public List<MenuDishItemViewModel> DishMenu
    {
        get => dishMenu;
        set
        {
            if (SetField(ref dishMenu, value))
                RaisePropertyChanged();
        }
    }


    public MainWindowViewModel()
    {
        LoadRestaurant();
        LoadDishMenu();
        // 这里建立联系，在触发对应的Command时就会调用对应的函数了
        PlaceOrderCommand = new DelegateCommand() { ExecuteAction = PlaceOrder };
        SelectMenuItemCommand = new DelegateCommand() { ExecuteAction = SelectMenuItem };
    }

    private void LoadRestaurant()
    {
        Restaurant = new Restaurant()
        {
            Name = "CrazyElephant",
            Address = "M78,建议使用变身器，方便行路！",
            Telephone = "1145141919"
        };
    }

    private void LoadDishMenu()
    {
        XmlDataService xds = new XmlDataService();
        var dishList = xds.GetDishList();
        DishMenu = new List<MenuDishItemViewModel>();
        foreach (var dish in dishList)
        {
            MenuDishItemViewModel dishItem = new MenuDishItemViewModel
            {
                Dish = dish,
            };
            DishMenu.Add(dishItem);
        }
    }

    private void PlaceOrder(object? parameter)
    {
        var selectedDishes = DishMenu.Where(dm => dm.IsSelected).Select(i => $"Name:{i.Dish.Name}").ToList();
        IOrderService orderService = new MockOrderService();
        orderService.PlaceOrder(selectedDishes);

        MessageBox.Show($"订餐成功,共计数{itemsCount}");
    }

    private void SelectMenuItem(object? parameter)
    {
        ItemsCount = dishMenu.Count(dm => dm.IsSelected);
    }
}