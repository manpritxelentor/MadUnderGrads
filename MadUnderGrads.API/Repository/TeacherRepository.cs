using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface ITeacherRepository : IGenericRepository<TeacherModel>
    {
        bool IsTeacherExists(int id);
    }

    public class TeacherRepository : EfGenericRepository<TeacherModel>, ITeacherRepository
    {
        public TeacherRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        public bool IsTeacherExists(int id)
        {
            return GetAllNoTracking().Any(w => w.Id == id);
        }
    }
}