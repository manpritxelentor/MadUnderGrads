using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductApparelRepository : IGenericRepository<ProductApparelModel>
    {

    }

    public class ProductApparelRepository : EfGenericRepository<ProductApparelModel>, IProductApparelRepository
    {
        public ProductApparelRepository(IDataContext dataContext)
            : base(dataContext)
        {

        }
    }
}