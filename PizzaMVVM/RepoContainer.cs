using PizzaMVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace PizzaMVVM
{
    internal static class RepoContainer
    {
        private static IUnityContainer _container;
        static RepoContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<ICustomerRepository, CustomerRepository>(
                new ContainerControlledLifetimeManager() );
      
        }
        public static IUnityContainer Container => _container;
    }
}
