using CDub_Maui_Categories_API_Client.Models;
using CDub_Maui_Categories_API_Client.Services;

namespace CDub_Maui_Categories_API_Client.Views;

public partial class DetailPage : ContentPage
{

    ICategoryService _categoryService;
    bool isNewItem;

    public Category Category
    {
        get => BindingContext as Category;
        set => BindingContext = value;
    }

    public DetailPage(ICategoryService service, Category item)
	{
		InitializeComponent();
        _categoryService = service;
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
        if (Category.Id == 0)
            isNewItem = true;

        await _categoryService.SaveItemAsync(Category, isNewItem);
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