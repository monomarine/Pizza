using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVVM.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T value,
            [CallerMemberName] string property = "")
        {
            if (object.Equals(member, value)) return;
            member = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
       
    }
}
