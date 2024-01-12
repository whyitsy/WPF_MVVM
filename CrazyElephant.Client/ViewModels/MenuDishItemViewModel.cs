using CrazyElephant.Client.Models;

namespace CrazyElephant.Client.ViewModels;

public class MenuDishItemViewModel:ObservableObject
{
    public Dish Dish { get; set; }

	private bool isSelected;

	public bool IsSelected
    {
		get => isSelected;
        set
        {
            if(SetField(ref isSelected, value))
                RaisePropertyChanged();
        }
	}

}