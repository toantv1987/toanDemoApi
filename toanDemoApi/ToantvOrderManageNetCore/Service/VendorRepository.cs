using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;
using ToantvOrderManageNetCore.Service.Interfaces;
using ToantvOrderManageNetCore.Data;
namespace ToantvOrderManageNetCore.Service
{
    public class VendorRepository : IVendorRepository
    {
        private readonly OrdersManagerDbContext _context;
        public VendorRepository(OrdersManagerDbContext context)
        {
            _context = context;
        }
       
        public void AddVendor(Vendor vendor)
        {
            if (vendor==null)
            {
                throw new ArgumentNullException(nameof(vendor));
            }
            _context.Vendors.Add(vendor);

        }

        public Vendor GetVendor(int vendorId)
        {
           return _context.Vendors.FirstOrDefault(p => p.VenderId == vendorId);
        }

        public IEnumerable<Vendor> GetVendor()
        {
            return _context.Vendors.ToList<Vendor>();
        }
       public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
