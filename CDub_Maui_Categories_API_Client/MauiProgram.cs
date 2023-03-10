using CDub_Maui_Categories_API_Client.Services;
using CDub_Maui_Categories_API_Client.Views;

namespace CDub_Maui_Categories_API_Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        builder.Services.AddSingleton<ICategoryService, CategoryService>();
        builder.Services.AddSingleton<IRestService, RestService>();
	
        builder.Services.AddSingleton<CategoryListPage>();
		builder.Services.AddSingleton<App>();
		

        return builder.Build();
	}
}
