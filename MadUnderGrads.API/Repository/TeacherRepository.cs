using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface ITeacherRepository : IGenericRepository<TeacherModel>
    {

    }

    public class TeacherRepository : EfGenericRepository<TeacherModel>, ITeacherRepository
    {
        public TeacherRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }
    }
}