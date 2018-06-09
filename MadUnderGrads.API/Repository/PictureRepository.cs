using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IPictureRepository : IGenericRepository<PictureModel>
    {

    }

    public class PictureRepository : EfGenericRepository<PictureModel>, IPictureRepository
    {
        public PictureRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }
    }
}