using MediktapAdmin.ViewModels.Base;
using System;
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

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            ViewModel.OnContentRendered();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ViewModel.OnClosed();
        }
    }
}