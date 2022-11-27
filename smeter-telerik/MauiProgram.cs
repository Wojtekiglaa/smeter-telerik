using Microsoft.Extensions.Logging;
using Telerik.Maui.Controls.Compatibility;
using Plugin.Maui.Audio;
namespace smeter_telerik;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseTelerik()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Inter-Bold.otf", "InterBold");
                fonts.AddFont("Inter-Regular.otf", "InterRegular");
            });
		builder.Services.AddSingleton(AudioManager.Current);
		builder.Services.AddTransient<MainPage> ();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
