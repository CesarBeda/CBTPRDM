using TarefasApp.Services;

namespace TarefasApp.Pages;

public partial class AddAndEditPage : ContentPage
{
    private Task _task;
    private bool _isEditing;

    // Construtor para ADIÇÃO
    public AddAndEditPage()
    {
        InitializeComponent();
        _isEditing = false;
        this.Title = "Adicionar Tarefa";
        HeaderLabel.Text = "Adicionar Tarefa";
    }

    // Construtor para EDIÇÃO
    public AddAndEditPage(Task task)
    {
        InitializeComponent();
        _task = task;
        _isEditing = true;
        this.Title = "Editar Tarefa";
        HeaderLabel.Text = "Editar Tarefa";

        TitleEntry.Text = _task.Title;
        DescriptionEditor.Text = _task.Description;
        CreationDatePicker.Date = _task.CreationDate;
        PriorityPicker.SelectedItem = _task.Priority;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Error", "The task title cannot be empty.", "OK");
            return;
        }

        if (_isEditing)
        {
            _task.Title = TitleEntry.Text;
            _task.Description = DescriptionEditor.Text;
            _task.CreationDate = CreationDatePicker.Date;
            _task.Priority = (string)PriorityPicker.SelectedItem;
        }
        else
        {
            var newTask = new Task
            {
                Title = TitleEntry.Text,
                Description = DescriptionEditor.Text,
                CreationDate = CreationDatePicker.Date,
                Priority = (string)PriorityPicker.SelectedItem ?? "Média"
            };
            TaskService.AddTask(newTask);
        }
        await Navigation.PopModalAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}