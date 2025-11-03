using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeuAppLogistica.ViewModels
{
    // Esta classe implementa a interface que notifica a View (XAML)
    // quando uma propriedade da ViewModel muda.
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Um método helper para facilitar a atualização de propriedades
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}