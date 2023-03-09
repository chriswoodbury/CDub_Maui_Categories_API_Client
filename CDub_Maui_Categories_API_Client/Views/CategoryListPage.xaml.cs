using CDub_Maui_Categories_API_Client.Models;

namespace CDub_Maui_Categories_API_Client.Views;

public partial class CategoryListPage : ContentPage
{
    List<Category> _categories;

    public CategoryListPage()
    {
        InitializeComponent();

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await GetCategories();

        //collectionView.ItemsSource = await _todoService.GetTasksAsync();
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
        
    public async Task<IEnumerable<Category>> GetCategories()
    {
        List<Category> _categoryList = new List<Category>();
        _categoryList.Add(new Category { Id = 1, Name = "Category 1", DisplayOrder = 1 });
        _categoryList.Add(new Category { Id = 2, Name = "Category 2", DisplayOrder = 2 });
        _categoryList.Add(new Category { Id = 3, Name = "Category 3", DisplayOrder = 3 });

        return _categoryList;
    }

    private void SwipeItem_Clicked(object sender, EventArgs e)
    {

    }
}