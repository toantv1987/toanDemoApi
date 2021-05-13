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
    [Route("api/v1/category")]
    public class CategoryController : Controller 
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            var categorysFromRepo = _categoryRepository.GetCategory();
            return Ok(categorysFromRepo);
        }
        [HttpGet("{categoryId}",Name = "GetCategory")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            var categorysFromRepo = _categoryRepository.GetCategory(categoryId);
            if (categorysFromRepo==null)
            {
                return NotFound();
            }
            return Ok(categorysFromRepo);
        }
        [HttpPost]
        public ActionResult<Category> AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
            _categoryRepository.Save();

            return CreatedAtRoute("GetCategory", new { category.CategoryId }, category);
        }
    }
}
