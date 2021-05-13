using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Service;
using toanDemoApi.Service.Interfaces;
using toanDemoApi.Data.Entities;
namespace toanDemoApi.Controllers
{
    public class CompanyOrder2Controller : Controller
    {
        ICompanyOrderRepository _companyOrderRepo;
        public CompanyOrder2Controller(ICompanyOrderRepository companyOrderRepository)
        {
            _companyOrderRepo = companyOrderRepository;
        }
        public IActionResult Index()
        {
            var co = _companyOrderRepo.GetCompanyOrder();
            return View(co);
        }
    }
}
