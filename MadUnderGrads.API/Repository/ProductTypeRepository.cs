using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductTypeRepository : IGenericRepository<ProductTypeModel>
    {
        IQueryable<ProductTypeModel> GetByCategory(string categoryCode);
    }

    public class ProductTypeRepository : EfGenericRepository<ProductTypeModel>, IProductTypeRepository
    {
        public ProductTypeRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }

        public IQueryable<ProductTypeModel> GetByCategory(string categoryCode)
        {
            return GetAllNoTracking().Where(w => w.Category.Code == categoryCode);
        }
    }
}