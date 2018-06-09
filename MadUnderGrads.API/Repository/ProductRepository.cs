using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {

    }

    public class ProductRepository : EfGenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }
    }
}