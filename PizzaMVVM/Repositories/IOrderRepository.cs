using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMVVM.Models;

namespace PizzaMVVM.Repositories
{
    internal interface IOrderRepository
    {
        //получить список всех заказов для конкретного клиента
        Task<List<Order>> GetOrdersByCustomerAsync(Guid customerID);
        //получить список всех заказов в системе
        Task<List<Order>> GetOrdersAsync();
        //добавить заказ в систему (новый)
        Task<Order> AddOrderAsync(Order order);
        //обновить заказ
        Task<Order> UpdateOrderAsync(Order order);
        //удалить заказ из системы
        Task DeleteOrderAsync(long orderID);


        //получить список всех продуктов
        Task<List<Product>> GetProductsAsync(); 
        //получить список всех ингредиентов
        Task<List<ProductOption>> GetProductOptionsAsync();
        //получить варианты размеров порций
        Task<List<ProductSize>> GetProductSizesAsync(); 
        //получить список статусов заказов
        Task<List<OrderStatus>> GetOrderStatusAsync();  
        
    }
}
