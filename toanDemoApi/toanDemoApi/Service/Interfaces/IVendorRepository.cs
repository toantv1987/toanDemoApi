using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Data.Entities;

namespace toanDemoApi.Service.Interfaces
{
    public interface IVendorRepository
    {
        Vendor GetVendor(int vendorId);
        IEnumerable<Vendor> GetVendor();
        void AddVendor(Vendor vendor);
    }
}
