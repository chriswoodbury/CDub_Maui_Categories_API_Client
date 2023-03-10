using CDub_Maui_Categories_API_Client.Models;
using CDub_Maui_Categories_API_Client.Services;

namespace CDub_Maui_Categories_API_Client.Views;

public partial class CategoryListPage : ContentPage
{
    ICategoryService _categoryService;

    public CategoryListPage(ICategoryService service)
    {
        InitializeComponent();
        _categoryService= service;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        //collectionView.ItemsSource = await GetCategories();
       
        collectionView.ItemsSource = await _categoryService.GetAllCategories();
    }

    async void OnAddItemClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetailPage(new Category()));

    }

    async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Category item)
            return;

        await Navigation.PushAsync(new DetailPage(item));
    }

    async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        collectionView.ItemsSource = await _categoryService.GetAllCategories();
    }

   
}