using PizzaMVVM.Models;
using PizzaMVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVVM.ViewModels
{
    internal class CustomersViewModel : BaseViewModel
    {
        private ICustomerRepository _customerRepository;
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        public CustomersViewModel()
        {
            _customerRepository = new CustomerRepository();
            LoadCustomers();

            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            PlaceNewOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            ClearSearchInputCommand = new RelayCommand(ClearSearch);
        }

        private List<Customer> _customerList;
        private async Task LoadCustomers()
        {
            _customerList = await _customerRepository.GetCustomersAsync();
            Customers = new ObservableCollection<Customer>(_customerList);
            
        }

        //поиск клиентов
        private string _searchInput;
        public string SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FindCustomerByName(_searchInput);
            }
        }

        public void FindCustomerByName(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Customers = new ObservableCollection<Customer>(_customerList);
                return;
            }
            else
            {
                Customers = new ObservableCollection<Customer>(
                    _customerList.Where(x => x.FullName.ToLower()
                    .Contains(text.ToLower())));
            }
        }

        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand<Customer> EditCustomerCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }  
        public RelayCommand<Customer> PlaceNewOrderCommand { get; private set; }

        public event Action<Guid> PlaceOrderRequested;
        public event Action<Customer> AddNewCustomerRequested;
        public event Action<Customer> EditCustomerRequested;

        private void OnAddCustomer() => 
            AddNewCustomerRequested?.Invoke(new Customer() { Id = new Guid() });

        private void OnEditCustomer(Customer customer) =>
            EditCustomerRequested?.Invoke(customer);

        private void ClearSearch() =>
            SearchInput = null;

        private void OnPlaceOrder(Customer customer) =>
            PlaceOrderRequested.Invoke(customer.Id);




    }
}
