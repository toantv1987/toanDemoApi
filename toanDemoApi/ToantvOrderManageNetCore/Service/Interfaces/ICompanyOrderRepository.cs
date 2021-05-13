using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;

namespace ToantvOrderManageNetCore.Service.Interfaces
{
    public interface ICompanyOrderRepository
    {
        //Get Company Order
        CompanyOrder GetCompanyOrder(int companyOrderId);
        /// <summary>
        /// Get a list Company Order
        /// </summary>
        /// <returns></returns>
        IEnumerable<CompanyOrder> GetCompanyOrder();
        /// <summary>
        /// Add a list Company Order
        /// </summary>
        /// <param name="Company Order"></param>
        void AddCompanyOrder(CompanyOrder companyOrder);
        bool Save();
    }
}
