using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductMisellanousRepository : IGenericRepository<ProductMisellanousModel>
    {

    }

    public class ProductMisellanousRepository : EfGenericRepository<ProductMisellanousModel>, IProductMisellanousRepository
    {
        public ProductMisellanousRepository(IDataContext dataContext)
            : base(dataContext)
        {

        }
    }
}