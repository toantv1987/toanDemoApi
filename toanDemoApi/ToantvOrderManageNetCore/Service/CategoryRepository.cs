using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ToantvOrderManageNetCore.Data.Entities;
using ToantvOrderManageNetCore.Service.Interfaces;
using ToantvOrderManageNetCore.Data;
namespace ToantvOrderManageNetCore.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OrdersManagerDbContext _context;
        public CategoryRepository(OrdersManagerDbContext context)
        {
            _context = context;
        }
       
        public void AddCategory(Category vendor)
        {
            if (vendor==null)
            {
                throw new ArgumentNullException(nameof(vendor));
            }
            _context.Categories.Add(vendor);

        }

        public Category GetCategory(int cateId)
        {
           return _context.Categories.FirstOrDefault(p => p.CategoryId == cateId);
        }

        public IEnumerable<Category> GetCategory()
        {
            return _context.Categories.ToList<Category>();
        }
       public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
