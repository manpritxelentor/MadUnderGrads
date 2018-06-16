using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IGenericRepository<T>
        where T : IBaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllNoTracking();
        T Create();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(object id);
    }


    public class EfGenericRepository<T> : IGenericRepository<T>
        where T : IBaseEntity
    {
        protected readonly IDataContext _dataContext;
        public EfGenericRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public T Create()
        {
            return _dataContext.Create<T>();
        }

        public virtual void Delete(T entity)
        {
            _dataContext.Delete(entity);
        }

        public virtual void DeleteById(object id)
        {
            var entity = GetById(id);
            if (entity != null)
                _dataContext.Delete(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dataContext.Entities<T>();
        }

        public virtual IQueryable<T> GetAllNoTracking()
        {
            return _dataContext.EntitiesNoTracking<T>();
        }

        public virtual T GetById(object id)
        {
            return _dataContext.GetById<T>(id);
        }

        public virtual void Insert(T entity)
        {
            _dataContext.Insert(entity);
        }

        public virtual void Update(T entity)
        {
            _dataContext.Update(entity);
        }
    }
}