using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace toanDemoApi.Data.Models.Vendor
{
    public class VendorDto
    {
        [Key]
        public int VenderId { get; set; }
        
        public string VendorName { get; set; }
    }
}
