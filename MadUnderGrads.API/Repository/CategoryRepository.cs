using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface ICategoryRepository : IGenericRepository<CategoryModel>
    {
        bool IsCategoryPresent(int categoryId);
        CategoryModel GetByCode(string categoryCode);
        int GetCategoryIdByCode(string categoryCode);
    }

    public class CategoryRepository : EfGenericRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }

        public CategoryModel GetByCode(string categoryCode)
        {
            return GetAllNoTracking()
                .FirstOrDefault(w => w.Code == categoryCode);
        }

        public int GetCategoryIdByCode(string categoryCode)
        {
            return GetAllNoTracking().Where(w => w.Code == categoryCode)
                .Select(w => w.Id).DefaultIfEmpty().FirstOrDefault();
        }

        public bool IsCategoryPresent(int categoryId)
        {
            return GetAllNoTracking()
                .Any(w => w.Id == categoryId);
        }
    }
}