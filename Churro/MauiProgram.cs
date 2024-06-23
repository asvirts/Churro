using Microsoft.Extensions.Logging;
using Supabase;

namespace Churro
{
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
				});

			//Supabase
			var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
			var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");

			var options = new SupabaseOptions
			{
				AutoRefreshToken = true,
				AutoConnectRealtime = true,
				// SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
			};

			// Note the creation as a singleton.
			builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));


			builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
