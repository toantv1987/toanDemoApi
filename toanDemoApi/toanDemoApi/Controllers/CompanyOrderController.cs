using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Data.Entities;
using toanDemoApi.Data.Models.CompanyOrder;
using toanDemoApi.Data.Models.Vendor;
using toanDemoApi.Service;
using toanDemoApi.Service.Interfaces;
namespace toanDemoApi.Controllers
{
    [ApiController]
    [Route("api/v1/companyOrder")]
    public class CompanyOrderController : ControllerBase
    {
        private ICompanyOrderRepository companyOrderRepository;
        public CompanyOrderController(ICompanyOrderRepository categoryRepository)
        {
            companyOrderRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<CompanyOrder>> GetCompanyOrder()
        {
            var companyOrderFromRepo = companyOrderRepository.GetCompanyOrder();
            return Ok(companyOrderFromRepo);
        }
        [HttpGet("{CompanyOrderId}", Name = "GetCompanyOrder")] 
       
        public ActionResult<CompanyOrderDto> GetCompanyOrder(int companyOrderId)
        {
            var companyOrderFromRepo = companyOrderRepository.GetCompanyOrder(companyOrderId);
            if (companyOrderFromRepo == null)
            {
                return NotFound();
            }
            var companyOrderDto = new CompanyOrderDto
            {
                CompanyOrderId = companyOrderFromRepo.CompanyOrderId, 
                InternalOrderNo = companyOrderFromRepo.InternalOrderNo,
                ExternalOrderNo = companyOrderFromRepo.ExternalOrderNo,
                VendorId = companyOrderFromRepo.VendorId,
                PurchaseDate = companyOrderFromRepo.PurchaseDate,
                ArrivalDate = companyOrderFromRepo.ArrivalDate,
                Status = companyOrderFromRepo.Status,
                Amount = companyOrderFromRepo.Amount,
                Comments = companyOrderFromRepo.Comments,
                TransitDays= (companyOrderFromRepo.ArrivalDate - companyOrderFromRepo.PurchaseDate).TotalDays,
                VendorDto = new VendorDto
                {
                    VenderId = companyOrderFromRepo.Vendor.VenderId,
                    VendorName = companyOrderFromRepo.Vendor.VendorName
                }
            };

            return Ok(companyOrderDto);
        }
        [HttpPost]
        public ActionResult<CompanyOrder> AddCompanyOrder(CompanyOrder category)
        {
            companyOrderRepository.AddCompanyOrder(category);
            companyOrderRepository.Save();

            return CreatedAtRoute("GetCompanyOrder", new { category.CompanyOrderId }, category);
        }
    }
}
