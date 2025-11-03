using Foundation;
using MeuAppLogistica.Views;

namespace MeuAppLogistica
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => Views.MauiProgram.CreateMauiApp();
    }
}
