using Microsoft.EntityFrameworkCore;
using PizzaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Documents;

namespace PizzaMVVM.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly PizzaDbContext _context = new();

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
       
        //*--------
        public async Task DeleteOrderAsync(long orderID)//-----------------------------
        {
            /*var order = _context.Orders.FirstOrDefault(x => x.Id == orderID);
            if(order != null)
            {
                _context.Orders.Remove(order);
            }
            await _context.SaveChangesAsync();
         */
            using (TransactionScope scope = new TransactionScope())
            {
                var order = _context.Orders.Include("OrderItems")
                    .Include("OrderItems.OrderItemsOptions")
                    .FirstOrDefault(o => o.Id == orderID);

                if (order != null)
                {
                    foreach (OrderItem item in order.OrderItems)
                    {
                        foreach (var itemOpt in item.OrderItemOptions)
                        {
                            _context.OrderItemOptions.Remove(itemOpt);
                        }
                        _context.OrderItems.Remove(item);
                    }
                    _context.Orders.Remove(order);
                }

                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }
        public Task<List<Order>> GetOrdersAsync() => _context.Orders.ToListAsync();

        public Task<List<Order>> GetOrdersByCustomerAsync(Guid customerID)=>
            _context.Orders
                    .Where(x => x.CustomerId == customerID)
                    .ToListAsync();
        
        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (!_context.Orders.Local.Any(x => x.CustomerId == order.CustomerId))
            {
                _context.Orders.Attach(order);
            }
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }

        public Task<List<Product>> GetProductsAsync()=>  _context.Products.ToListAsync(); 
       

        public Task<List<ProductOption>> GetProductOptionsAsync()=> _context.ProductOptions.ToListAsync();

        public Task<List<ProductSize>> GetProductSizesAsync() => _context.ProductSizes.ToListAsync();   
       

        public Task<List<OrderStatus>> GetOrderStatusAsync() =>_context.OrderStatuses.ToListAsync();    
    }
}
