﻿using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        /// <summary>
        /// Gets the product by category which are not sold
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        IQueryable<ProductModel> GetbyCategory(string categoryCode);
        IQueryable<ProductModel> GetByUserAndCategory(string categoryCode, string userId);
        ProductModel GetByIdNoTracking(int id);
    }

    public class ProductRepository : EfGenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Gets the product by category which are not sold
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public IQueryable<ProductModel> GetbyCategory(string categoryCode)
        {
            return GetAllNoTracking()
                .Where(w => !w.IsSold && w.Category.Code == categoryCode);
        }

        public IQueryable<ProductModel> GetByUserAndCategory(string categoryCode, string userId)
        {
            if(string.IsNullOrEmpty(categoryCode))
                categoryCode = null;
            return GetAllNoTracking()
                .Where(w => (categoryCode == null || w.Category.Code == categoryCode)
                && w.CreatedBy == userId);
        }

        public ProductModel GetByIdNoTracking(int id)
        {
            return GetAllNoTracking()
                .FirstOrDefault(w => w.Id == id);
        }
    }
}