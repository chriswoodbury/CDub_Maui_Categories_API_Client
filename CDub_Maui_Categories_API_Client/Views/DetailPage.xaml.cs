using CDub_Maui_Categories_API_Client.Models;

namespace CDub_Maui_Categories_API_Client.Views;

public partial class DetailPage : ContentPage
{
    public Category Category
    {
        get => BindingContext as Category;
        set => BindingContext = value;
    }

    public DetailPage(Category item)
	{
		InitializeComponent();
        Category = item;
        if (item.Id == 0)
        {
            lblPageHeading.Text = "Add New Category";
        }
        else
        {
            lblPageHeading.Text = $"Edit {item.Name}";
        }

 	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        //await _todoService.SaveTaskAsync(TodoItem, _isNewItem);
        await Navigation.PopAsync();
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        //await _todoService.DeleteTaskAsync(TodoItem);
        await Navigation.PopAsync();
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}