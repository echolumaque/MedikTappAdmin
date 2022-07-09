using MediktapAdmin.Services.NavigationService;
using MediktapAdmin.Templates;
using System.ComponentModel;
using System.Windows.Input;

namespace MediktapAdmin.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            GoBackCmd = new Command(() => navigationService.GoBack()); 
        }

        protected NavigationService NavigationService { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public virtual void OnNavigatedFrom(NavigationParameters parameters) { }

        public virtual void OnNavigatedTo(NavigationParameters parameters) { }

        public virtual void SetBindings(NavigationParameters parameters) { }
        public ICommand GoBackCmd { get;  }
    }
}