using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toanDemoApi.Data.Models.Vendor;

namespace toanDemoApi.Data.Models.CompanyOrder
{
    public class CompanyOrderDto
    {

        public int CompanyOrderId { get; set; }

        public string InternalOrderNo { get; set; } 
        public string ExternalOrderNo { get; set; } 
        public int? VendorId { get; set; } 
        public DateTime? PurchaseDate { get; set; } 
        public DateTime? ArrivalDate { get; set; } 
        public string Status { get; set; } 
        //[Sieve(CanSort = true)]
        public int? Amount { get; set; }

        public string Comments { get; set; }
        public VendorDto VendorDto { get; set; }
        public double TransitDays { get; set; }

    }
}
