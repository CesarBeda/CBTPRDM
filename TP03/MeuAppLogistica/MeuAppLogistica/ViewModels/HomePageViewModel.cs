using MeuAppLogistica.Services;
using MeuAppLogistica.Models;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Maui.Controls; // Essencial para Shell e Command
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MeuAppLogistica.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private string _trackingCode;
        private readonly MockTrackingService _trackingService;

        // Propriedade para onde o XAML Entry vai ligar (Data Binding)
        public string TrackingCode
        {
            get => _trackingCode;
            set => SetProperty(ref _trackingCode, value);
        }

        // Comando para onde o XAML Button vai ligar
        public ICommand SearchCommand { get; }

        public HomePageViewModel(MockTrackingService trackingService)
        {
            _trackingService = trackingService;

            // O Comando chama o método SearchPackageAsync
            // Note o uso de 'async' no lambda para chamadas assíncronas.
            SearchCommand = new Command(async () => await SearchPackageAsync(), () => !string.IsNullOrWhiteSpace(TrackingCode));

            // Isso atualiza o estado CanExecute do Command (para habilitar/desabilitar o botão)
            this.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(TrackingCode))
                {
                    (SearchCommand as Command).ChangeCanExecute();
                }
            };
        }

        private async Task SearchPackageAsync()
        {
            if (string.IsNullOrWhiteSpace(TrackingCode))
                return;

            var package = await _trackingService.GetPackageDetailsAsync(TrackingCode);

            if (package == null)
            {
                // Usa o DisplayAlert da Aula 04 [cite: 461, 463]
                await Shell.Current.DisplayAlert("Erro", "Código de rastreio não encontrado.", "OK");
            }
            else
            {
                // Navega para a página de resultados (Aula 05) 
                // Estamos passando os dados usando o método de navegação do Shell.
                // Isso é uma alternativa moderna ao BindingContext direto [cite: 147] ou construtor[cite: 139].
                var navigationParams = new Dictionary<string, object>
                {
                    { "PackageData", package } // O objeto 'package' será enviado
                };

                // "ResultsPage" é o nome da rota que vamos registrar
                await Shell.Current.GoToAsync("ResultsPage", navigationParams);
            }
        }
    }
}