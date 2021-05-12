using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Data.Entities;
using toanDemoApi.Service.Interfaces;
using toanDemoApi.Data;
namespace toanDemoApi.Service
{
    public class VendorRepository : IVendorRepository
    {
        private readonly OrdersManagerDbContext _context;
       
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
       
    }
}
