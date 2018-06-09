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
    }

    public class CategoryRepository : EfGenericRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }

        public bool IsCategoryPresent(int categoryId)
        {
            return GetAllNoTracking()
                .Any(w => w.Id == categoryId);
        }
    }
}