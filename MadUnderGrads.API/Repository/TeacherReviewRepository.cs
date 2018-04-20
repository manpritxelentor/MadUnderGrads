using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface ITeacherReviewRepository : IGenericRepository<TeacherReviewModel>
    {

    }

    public class TeacherReviewRepository : EfGenericRepository<TeacherReviewModel>, ITeacherReviewRepository
    {
        public TeacherReviewRepository(IDataContext dataContext) 
            : base(dataContext)
        {
        }
    }
}