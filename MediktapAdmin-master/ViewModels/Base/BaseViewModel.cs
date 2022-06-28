using MediktapAdmin.Services.NavigationService;
using System.ComponentModel;

namespace MediktapAdmin.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected NavigationService NavigationService { get; }

        public virtual void OnContentRendered() { }

        public virtual void OnClosed() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}