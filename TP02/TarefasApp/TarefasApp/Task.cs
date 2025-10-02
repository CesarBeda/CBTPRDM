using System.ComponentModel;
using System.Runtime.CompilerServices;

// INotifyPropertyChanged para notificar a UI sobre alterações nas propriedades.
public class Task : INotifyPropertyChanged
{
    // Propriedades privadas
    private string _title;
    private string _description;
    private DateTime _creationDate;
    private string _priority;

    // Identificador único para cada tarefa
    public Guid Id { get; set; } = Guid.NewGuid();

    // Propriedade pública para o Título
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    // Propriedade pública para a Descrição
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    // Propriedade pública para a Data de Criação
    public DateTime CreationDate
    {
        get => _creationDate;
        set => SetProperty(ref _creationDate, value);
    }

    // Propriedade pública para a Prioridade
    public string Priority
    {
        get => _priority;
        set => SetProperty(ref _priority, value);
    }

    // Implementação do INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
