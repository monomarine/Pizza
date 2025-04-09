using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVVM.ViewModels
{
    internal class CustomersViewModel : BaseViewModel
    {
        private string fullName;
        public string FullName { 
            get => fullName;
            set => SetProperty(ref fullName, value, nameof(FullName));   
        }
    }
}
