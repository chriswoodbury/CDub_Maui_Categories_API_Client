using CDub_Maui_Categories_API_Client.Views;

namespace CDub_Maui_Categories_API_Client;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new CategoryListPage());
	}
}
