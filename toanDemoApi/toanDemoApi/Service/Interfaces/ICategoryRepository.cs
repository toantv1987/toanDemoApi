using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using toanDemoApi.Data.Entities;

namespace toanDemoApi.Service.Interfaces
{
    public interface ICategoryRepository
    {
        //Get vendor
        Category GetCategory(int categoryId);
        /// <summary>
        /// Get a list vendor
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategory();
        /// <summary>
        /// Add a list vendor
        /// </summary>
        /// <param name="vendor"></param>
        void AddCategory(Category category);
        bool Save();
    }
}
