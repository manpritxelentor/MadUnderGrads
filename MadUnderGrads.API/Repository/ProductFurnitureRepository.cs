using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductFurnitureRepository : IGenericRepository<ProductFurnitureModel>
    {

    }

    public class ProductFurnitureRepository : EfGenericRepository<ProductFurnitureModel>, IProductFurnitureRepository
    {
        public ProductFurnitureRepository(IDataContext dataContext)
            : base(dataContext)
        {

        }
    }
}