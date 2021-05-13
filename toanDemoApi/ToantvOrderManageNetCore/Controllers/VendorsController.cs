using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;
using ToantvOrderManageNetCore.Service;
using ToantvOrderManageNetCore.Service.Interfaces;
namespace ToantvOrderManageNetCore.Controllers
{
    [ApiController]
    [Route("api/v1/vendors")]
    public class VendorsController : Controller
    {
        private IVendorRepository _vendorRepository;
        public VendorsController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository ?? throw new ArgumentNullException(nameof(vendorRepository));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Vendor>> GetVendor()
        {
            var vendorsFromRepo = _vendorRepository.GetVendor();
            return Ok(vendorsFromRepo);
        }
        [HttpGet("{vendorId}",Name = "GetVendor")]
        public ActionResult<Vendor> GetVendor(int vendorId)
        {
            var vendorsFromRepo = _vendorRepository.GetVendor(vendorId);
            if (vendorsFromRepo==null)
            {
                return NotFound();
            }
            return Ok(vendorsFromRepo);
        }
        [HttpPost]
        public ActionResult<Vendor> AddVendor(Vendor vendor)
        {
            _vendorRepository.AddVendor(vendor);
            _vendorRepository.Save();

            return CreatedAtRoute("GetVendor", new { vendor.VenderId }, vendor);
        }
    }
}
