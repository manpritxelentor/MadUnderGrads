using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface ITeacherReviewRepository : IGenericRepository<TeacherReviewModel>
    {
        IQueryable<TeacherReviewModel> GetByTeacherId(int teacherId);
    }

    public class TeacherReviewRepository : EfGenericRepository<TeacherReviewModel>, ITeacherReviewRepository
    {
        public TeacherReviewRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        public override IQueryable<TeacherReviewModel> GetAll()
        {
            return base.GetAll().OrderByDescending(w => w.ReviewDate);
        }

        public override IQueryable<TeacherReviewModel> GetAllNoTracking()
        {
            return base.GetAllNoTracking().OrderByDescending(w => w.ReviewDate);
        }

        public IQueryable<TeacherReviewModel> GetByTeacherId(int teacherId)
        {
            return GetAllNoTracking().Where(w => w.TeacherId == teacherId)
                .OrderByDescending(w => w.ReviewDate);
        }
    }
}