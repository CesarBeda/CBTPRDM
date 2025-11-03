using MeuAppLogistica.ViewModels;

namespace MeuAppLogistica.Views;

public partial class ResultsPage : ContentPage
{
    public ResultsPage(ResultsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}