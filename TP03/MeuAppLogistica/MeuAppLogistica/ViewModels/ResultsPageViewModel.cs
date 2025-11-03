using Microsoft.Maui.Controls;
using MeuAppLogistica.Models;

namespace MeuAppLogistica.ViewModels
{
    // Esta ViewModel precisa receber os dados da navegação
    [QueryProperty(nameof(Package), "PackageData")]
    public class ResultsPageViewModel : BaseViewModel
    {
        private Package _package;

        public Package Package
        {
            get => _package;
            set => SetProperty(ref _package, value);
        }

        public ResultsPageViewModel()
        {
        }
    }
}