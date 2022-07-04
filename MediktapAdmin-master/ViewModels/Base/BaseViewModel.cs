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


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public virtual void OnNavigatedFrom(NavigationParameters parameters) { }

        public virtual void OnNavigatedTo(NavigationParameters parameters) { }

        public virtual void SetBindings(NavigationParameters parameters) { }
    }
}