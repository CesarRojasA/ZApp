using Microsoft.Extensions.Logging;
using ZApp.Interfaces;
using ZApp.Services;
using ZApp.ViewModels;
using ZApp.Views;

namespace ZApp;

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

		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<IApiService, ApiService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
