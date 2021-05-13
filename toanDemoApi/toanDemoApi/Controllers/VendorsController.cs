using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Data.Entities;
using toanDemoApi.Data.Models.Vendor;
using toanDemoApi.Service;
using toanDemoApi.Service.Interfaces;
namespace toanDemoApi.Controllers
{
    [ApiController]
    [Route("api/v1/vendors")]
    public class VendorsController : ControllerBase
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
        public ActionResult<VendorDto> GetVendor(int vendorId)
        {
            var vendorsFromRepo = _vendorRepository.GetVendor(vendorId);
            if (vendorsFromRepo==null)
            {
                return NotFound();
            }
            var vendorDto = new VendorDto
            {
                VenderId = vendorsFromRepo.VenderId,
                VendorName = vendorsFromRepo.VendorName
            };
            return Ok(vendorDto);
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
