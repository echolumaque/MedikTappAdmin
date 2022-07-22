using MediktapAdmin.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MediktapAdmin.Views.Services.ViewModel
{
    public partial class ServiceViewModel
    {
        public string AddButtonText { get; set; }
        public ICommand AddNewCmd { get; set; }
        public string DeleteButtonText { get; set; }
        public ICommand DeleteCmd { get; set; }
        public string EditButtonText { get; set; }
        public ICommand EditCmd { get; set; }
        public ObservableCollection<Service> Promos { get; set; }
        public Service SelectedPromo { get; set; }
        public Service SelectedService { get; set; }
        [OnChangedMethod(nameof(SelectedTabChanged))]
        public TabItem SelectedTab { get; set; }
        public ObservableCollection<Service> Services { get; set; }
    }
}