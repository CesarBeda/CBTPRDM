using System.Collections.ObjectModel;

namespace TarefasApp.Services
{
    public static class TaskService
    {
        public static ObservableCollection<Task> Tasks { get; private set; } = new();

        static TaskService()
        {
            Tasks.Add(new Task
            {
                Title = "Estudar .NET MAUI",
                Description = "Verifique a documentação de Collection View",
                CreationDate = DateTime.Now,
                Priority = "Alta"
            });
        }

        public static void AddTask(Task task)
        {
            if (task != null)
            {
                Tasks.Add(task);
            }
        }

        public static void DeleteTask(Guid taskId)
        {
            var taskToRemove = Tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                Tasks.Remove(taskToRemove);
            }
        }
    }
}