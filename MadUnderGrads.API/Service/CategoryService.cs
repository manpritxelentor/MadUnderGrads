using MadUnderGrads.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Service
{
    public interface ICategoryService
    {
        bool IsCategoryPresent(int id);
    }

    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public bool IsCategoryPresent(int id)
        {
            return categoryRepository.IsCategoryPresent(id);
        }
    }
}