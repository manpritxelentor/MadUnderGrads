using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductTextBookRepository : IGenericRepository<ProductTextbookModel>
    {
        IQueryable<ProductTextbookModel> GetBooksByUserId(string userId);
    }

    public class ProductTextBookRepository : EfGenericRepository<ProductTextbookModel>, IProductTextBookRepository
    {
        public ProductTextBookRepository(IDataContext dataContext)
            : base(dataContext)
        {
            
        }

        public IQueryable<ProductTextbookModel> GetBooksByUserId(string userId)
        {
            return GetAllNoTracking()
                .Where(w => w.Product.CreatedBy == userId);
        }
    }
}