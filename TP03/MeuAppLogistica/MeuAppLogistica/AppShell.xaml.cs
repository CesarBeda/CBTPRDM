using MeuAppLogistica.Views;

namespace MeuAppLogistica
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ResultsPage", typeof(ResultsPage));
        }
    }
}
