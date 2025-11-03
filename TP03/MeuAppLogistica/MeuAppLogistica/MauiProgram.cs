using MeuAppLogistica.Services;
using MeuAppLogistica.ViewModels;
using MeuAppLogistica.Views;

namespace MeuAppLogistica;

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

        // --- Registro de Dependências ---

        // Registrar o Serviço (Singleton, pois só precisamos de um)
        builder.Services.AddSingleton<MockTrackingService>();

        // Registrar Views e ViewModels (Transient, pois queremos novas a cada vez)
        // Isso permite a Injeção de Dependência nos construtores
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomePageViewModel>();

        builder.Services.AddTransient<ResultsPage>();
        builder.Services.AddTransient<ResultsPageViewModel>();

        // --- Fim do Registro ---

        return builder.Build();
    }
}