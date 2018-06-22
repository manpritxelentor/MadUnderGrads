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
    public interface IProductTypeService
    {
        IEnumerable<ProductTypeDataModel> GetByCategory(string categoryCode);
        ProductTypeDataModel GetById(int id);
        ProductTypeDataModel Insert(ProductTypeDataModel model, string categoryCode, string userId);
        ProductTypeDataModel Update(int productTypeId, ProductTypeDataModel model, string categoryCode, string userId);
        bool Delete(int id);
    }

    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingUtility mappingUtility;
        private readonly ICategoryRepository categoryRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository
            , IUnitOfWork unitOfWork
            , IMappingUtility mappingUtility
            , ICategoryRepository categoryRepository)
        {
            this.productTypeRepository = productTypeRepository;
            this.unitOfWork = unitOfWork;
            this.mappingUtility = mappingUtility;
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<ProductTypeDataModel> GetByCategory(string categoryCode)
        {
            return mappingUtility.Project<ProductTypeModel, ProductTypeDataModel>
                (productTypeRepository.GetByCategory(categoryCode)).ToList();
        }

        public ProductTypeDataModel GetById(int id)
        {
            var entity = productTypeRepository.GetById(id);
            if (entity == null)
                return null;
            return mappingUtility.Map<ProductTypeModel, ProductTypeDataModel>(entity);
        }

        public ProductTypeDataModel Insert(ProductTypeDataModel model, string categoryCode, string userId)
        {
            var entity = mappingUtility.Map<ProductTypeDataModel, ProductTypeModel>(model, productTypeRepository.Create());
            entity.CreatedBy = userId;
            entity.CreatedOn = DateTime.Now;
            productTypeRepository.Insert(entity);
            bool result = unitOfWork.Commit() > 0;
            if (result)
                return GetById(entity.Id);
            return null;
        }

        public ProductTypeDataModel Update(int productTypeId, ProductTypeDataModel model, string categoryCode, string userId)
        {
            var dataEntity = productTypeRepository.GetById(productTypeId);
            if (dataEntity == null)
                return null;
            var entity = mappingUtility.Map<ProductTypeDataModel, ProductTypeModel>(model, dataEntity);
            entity.ModifiedBy = userId;
            entity.ModifiedOn = DateTime.Now;
            productTypeRepository.Update(entity);
            bool result = unitOfWork.Commit() > 0;
            if (result)
                return GetById(entity.Id);
            return null;
        }

        public bool Delete(int id)
        {
            productTypeRepository.DeleteById(id);
            return unitOfWork.Commit() > 0;
        }
    }
}