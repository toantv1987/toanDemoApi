using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;

namespace ToantvOrderManageNetCore.Service.Interfaces
{
    public interface IOrderItemRepository
    {
        //Get vendor
        OrderItem GetOrderItem(int vendorId);
        /// <summary>
        /// Get a list vendor
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderItem> GetOrderItem();
        /// <summary>
        /// Add a list vendor
        /// </summary>
        /// <param name="vendor"></param>
        void AddOrderItem(OrderItem vendor);
        bool Save();
    }
}
