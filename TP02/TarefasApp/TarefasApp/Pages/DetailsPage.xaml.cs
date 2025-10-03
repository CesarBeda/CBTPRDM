using TarefasApp.Services;

namespace TarefasApp.Pages;

public partial class DetailsPage : ContentPage
{
    private Task _task;

    public DetailsPage(Task task)
    {
        InitializeComponent();
        _task = task;
        LoadTaskDetails();
    }

    private void LoadTaskDetails()
    {
        TitleLabel.Text = _task.Title;
        DescriptionLabel.Text = _task.Description;
        CreationDateLabel.Text = _task.CreationDate.ToString("dd/MM/yyyy");
        PriorityLabel.Text = _task.Priority;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddAndEditPage(_task));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmação de Apagamento", $"Tem a certeza de que deseja eliminar a tarefa '{_task.Title}'?", "Sim", "Não");

        if (confirm)
        {
            TaskService.DeleteTask(_task.Id);
            await Navigation.PopAsync();
        }
    }
}