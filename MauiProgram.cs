using Microsoft.Extensions.Logging;
using SoftwareAnalysis;

namespace SoftwareAnalysis
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<CategoryDbAccessor>();
			builder.Services.AddSingleton<CustomerDbAccessor>();
			builder.Services.AddSingleton<EquipmentDbAccessor>();
            builder.Services.AddSingleton<RentalDbAccessor>();
            return builder.Build();
        }
    }
}
