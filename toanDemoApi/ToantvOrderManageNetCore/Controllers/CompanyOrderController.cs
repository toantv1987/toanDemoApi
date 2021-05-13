using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;
using ToantvOrderManageNetCore.Data.Models.CompanyOrder;
using ToantvOrderManageNetCore.Data.Models.Vendor;
using ToantvOrderManageNetCore.Service;
using ToantvOrderManageNetCore.Service.Interfaces;
namespace ToantvOrderManageNetCore.Controllers
{
    //https://www.youtube.com/watch?v=Ryh03V4fhdo&list=PLDFCJqLpd2wS8sqm131Xo-B_e4YQTXixU&index=18
    public class CompanyOrderController : Controller
    {
        private ICompanyOrderRepository companyOrderRepository;
        public CompanyOrderController(ICompanyOrderRepository categoryRepository)
        {
            companyOrderRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        [HttpGet]
        public ActionResult GetCompanyOrder()
        {
           

            var companyOrderFromRepo = companyOrderRepository.GetCompanyOrder();
            if (companyOrderFromRepo == null)
            {
                return NotFound();
            }
            List<CompanyOrderDto> list=new List<CompanyOrderDto>();
            foreach (var item in companyOrderFromRepo)
            { 
                
                var companyOrderDto = new CompanyOrderDto
                {
                    CompanyOrderId = item.CompanyOrderId,

                    InternalOrderNo = item.InternalOrderNo,
                    ExternalOrderNo = item.ExternalOrderNo,
                    VendorId = item.VendorId,
                    PurchaseDate = item.PurchaseDate,
                    ArrivalDate = item.ArrivalDate,
                    Status = item.Status,
                    Amount = item.Amount,
                    Comments = item.Comments,
                    TransitDays = (item.ArrivalDate - item.PurchaseDate).TotalDays,
                    VendorDto = new VendorDto
                    {
                        VenderId = item.Vendor.VenderId,
                        VendorName = item.Vendor.VendorName
                    }
                    
                };
                list.Add(companyOrderDto);
            }
           

            return View(list);
        }
        [HttpGet("{categoryId}",Name = "GetCompanyOrder")]
        public ActionResult<CompanyOrder> GetCompanyOrder(int categoryId)
        {
            var companyOrder = companyOrderRepository.GetCompanyOrder(categoryId);
            if (companyOrder==null)
            {
                return NotFound();
            }
            return Ok(companyOrder);
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
