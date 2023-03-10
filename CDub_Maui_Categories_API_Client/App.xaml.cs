using CDub_Maui_Categories_API_Client.Services;
using CDub_Maui_Categories_API_Client.Views;

namespace CDub_Maui_Categories_API_Client;

public partial class App : Application
{	
	ICategoryService _categoryService;

	public App(ICategoryService service)
	{ 
		InitializeComponent();
		_categoryService = service;
		MainPage = new NavigationPage(new CategoryListPage(_categoryService));
	}
}
