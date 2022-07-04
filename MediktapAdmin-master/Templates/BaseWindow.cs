using MediktapAdmin.ViewModels.Base;
using System.Windows;

namespace MediktapAdmin.Templates
{
    public abstract class BaseWindow<TViewModel> : Window where TViewModel : BaseViewModel
    {
        public BaseWindow(in TViewModel viewModel)
        {
            DataContext = ViewModel = viewModel;
        }

        public TViewModel ViewModel { get; }
    }
}