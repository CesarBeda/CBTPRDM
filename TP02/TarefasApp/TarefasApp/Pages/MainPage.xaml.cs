// Pages/MainPage.xaml.cs
using TarefasApp.Services; // Importa nosso novo serviço!

namespace TarefasApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // A mágica acontece aqui:
            // O ItemsSource do nosso CollectionView agora aponta diretamente
            // para a lista estática dentro do TaskService.
            tasksCollectionView.ItemsSource = TaskService.Tasks;
        }

        // Não precisamos mais da propriedade 'Tasks' nem do método 'AddInitialData' aqui.
        // O TaskService agora cuida de tudo isso!

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddAndEditPage());
        }

        private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Task selectedTask)
            {
                await Navigation.PushAsync(new DetailsPage(selectedTask));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}