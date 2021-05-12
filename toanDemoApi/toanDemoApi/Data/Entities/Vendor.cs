using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace toanDemoApi.Data.Entities
{
    [Table("Vender")]
    public class Vendor
    {
        [Key]
        [Required]
        [Column("VenderId")]
        public int VenderId { get; set; }
        [Column("VendorName")]
        public string VendorName { get; set; }
    }
}
