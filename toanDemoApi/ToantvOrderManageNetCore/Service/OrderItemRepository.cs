using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;
using ToantvOrderManageNetCore.Service.Interfaces;
using ToantvOrderManageNetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ToantvOrderManageNetCore.Service
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrdersManagerDbContext _context;
        public OrderItemRepository(OrdersManagerDbContext context)
        {
            _context = context;
        }
       
        public void AddOrderItem(OrderItem orderItem)
        {
            if (orderItem==null)
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
            _context.OrderItems.Add(orderItem);

        }

        public OrderItem GetOrderItem(int orderItemId)
        {
           return _context.OrderItems.FirstOrDefault(p => p.OrderItemId== orderItemId);
        }

        public IEnumerable<OrderItem> GetOrderItem()
        {
            return _context.OrderItems
                            .Include(oi => oi.Category)
                            .Include(oi => oi.Order)
                            .ToList<OrderItem>();
        }
       public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
