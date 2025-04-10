using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PizzaMVVM.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private CustomersViewModel _customersViewModel;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewiModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
        public RelayCommand<string> NavigationCommand { get; private set; }

        public MainWindowViewModel()
        {
            NavigationCommand = new RelayCommand<string>(OnNavigate);
            _customersViewModel = RepoContainer.Container.Resolve<CustomersViewModel>();
        }
        private void OnNavigate(string destination)
        {
            switch(destination)
            {
                case "customers":
                default:
                    CurrentViewiModel =  _customersViewModel;
                    break;
            }
        }
    }
}
