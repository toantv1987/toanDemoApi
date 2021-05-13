using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;

namespace ToantvOrderManageNetCore.Service.Interfaces
{
    public interface IVendorRepository
    {
        //Get vendor
        Vendor GetVendor(int vendorId);
        /// <summary>
        /// Get a list vendor
        /// </summary>
        /// <returns></returns>
        IEnumerable<Vendor> GetVendor();
        /// <summary>
        /// Add a list vendor
        /// </summary>
        /// <param name="vendor"></param>
        void AddVendor(Vendor vendor);
        bool Save();
    }
}
