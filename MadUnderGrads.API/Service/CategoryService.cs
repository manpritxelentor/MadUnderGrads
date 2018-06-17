using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Models;
using MadUnderGrads.API.Repository;
using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Service
{
    public interface ICategoryService
    {
        bool IsCategoryPresent(int id);
        IEnumerable<CategoryDataModel> GetAll();
        CategoryDataModel GetByCode(string categoryCode);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMappingUtility mappingUtility;

        public CategoryService(ICategoryRepository categoryRepository
            , IMappingUtility mappingUtility)
        {
            this.categoryRepository = categoryRepository;
            this.mappingUtility = mappingUtility;
        }

        public IEnumerable<CategoryDataModel> GetAll()
        {
            return mappingUtility.Project<CategoryModel, CategoryDataModel>
                (categoryRepository.GetAllNoTracking())
                .ToList();
        }

        public CategoryDataModel GetByCode(string categoryCode)
        {
            CategoryModel categoryModel = categoryRepository.GetByCode(categoryCode);
            if (categoryModel == null)
                return null;
            return mappingUtility.Map<CategoryModel, CategoryDataModel>(categoryModel);
        }

        public bool IsCategoryPresent(int id)
        {
            return categoryRepository.IsCategoryPresent(id);
        }
    }
}