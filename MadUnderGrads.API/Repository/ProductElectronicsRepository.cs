using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductElectronicsRepository : IGenericRepository<ProductElectronicsModel>
    {

    }

    public class ProductElectronicsRepository : EfGenericRepository<ProductElectronicsModel>, IProductElectronicsRepository
    {
        public ProductElectronicsRepository(IDataContext dataContext)
            : base(dataContext)
        {

        }
    }
}