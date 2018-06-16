using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public interface IDataContext
    {
        IQueryable<T> Entities<T>() where T : IBaseEntity;
        IQueryable<T> EntitiesNoTracking<T>() where T : IBaseEntity;
        T GetById<T>(object id) where T : IBaseEntity;
        void Delete<T>(T entity) where T : IBaseEntity;
        void Insert<T>(T entity) where T : IBaseEntity;
        void Update<T>(T entity) where T : IBaseEntity;
        T Create<T>() where T : IBaseEntity;
        int SaveChanges();
    }
}