using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMVVM.Models;

namespace PizzaMVVM.Repositories
{
    internal interface ICustomerRepository
    {
        //получить список всех клиентов
        Task<List<Customer>> GetCustomersAsync(); 
        //найти клиента по id
        Task<Customer> GetCustomerBuIdAsync(Guid id);
        //обновить данные конкретного клиента
        Task<Customer> UpdateCustomerAsync(Customer customer);
        //удалить клиента
        Task DeleteCustomerAsync( Guid id);
        //создать клиента
        Task<Customer> AddCustomerAsync(Customer customer);

    }
}
