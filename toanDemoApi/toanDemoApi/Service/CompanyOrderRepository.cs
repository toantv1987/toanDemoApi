using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using toanDemoApi.Data.Entities;
using toanDemoApi.Service.Interfaces;
using toanDemoApi.Data;

namespace toanDemoApi.Service
{
    public class CompanyOrderRepository : ICompanyOrderRepository
    {
        private readonly OrdersManagerDbContext _context;
        public CompanyOrderRepository(OrdersManagerDbContext context)
        {
            _context = context;
        }
       
        public void AddCompanyOrder(CompanyOrder companyOrder)
        {
            if (companyOrder==null)
            {
                throw new ArgumentNullException(nameof(companyOrder));
            }
            _context.CompanyOrders.Add(companyOrder);

        }

        public CompanyOrder GetCompanyOrder(int companyOrderId)
        {
           return _context.CompanyOrders
                .Include(co=>co.Vendor)
                .FirstOrDefault(p => p.CompanyOrderId == companyOrderId);
        }

        public IEnumerable<CompanyOrder> GetCompanyOrder()
        {
            return _context.CompanyOrders
                .Include(p=>p.Vendor)
                .ToList<CompanyOrder>();
        }
       public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
