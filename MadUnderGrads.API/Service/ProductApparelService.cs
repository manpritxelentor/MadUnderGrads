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
    public interface IProductApparelService
    {
        IEnumerable<ProductApparelDataModel> GetAll();
        ProductApparelDataModel GetById(int id);
        bool Delete(int id);
        bool Insert(ProductApparelDataModel model);
        bool Update(int id, ProductApparelDataModel model);
    }

    public class ProductApparelService : IProductApparelService
    {
        private readonly IProductApparelRepository _productApparelRepository;
        private readonly IMappingUtility _mappingUtility;
        private readonly IUnitOfWork _unitOfWork;

        public ProductApparelService(IProductApparelRepository productApparelRepository
            , IMappingUtility mappingUtility
            , IUnitOfWork unitOfWork)
        {
            _productApparelRepository = productApparelRepository;
            _mappingUtility = mappingUtility;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductApparelDataModel> GetAll()
        {
            return _mappingUtility
                .Project<ProductApparelModel, ProductApparelDataModel>(
                _productApparelRepository.GetAll())
                .ToList();
        }

        public ProductApparelDataModel GetById(int id)
        {
            var data = _productApparelRepository.GetById(id);
            if (data == null)
                return null;
            return _mappingUtility.Map<ProductApparelModel, ProductApparelDataModel>(data);
        }

        public bool Delete(int id)
        {
            _productApparelRepository.DeleteById(id);
            return _unitOfWork.Commit() > 0;
        }

        public bool Insert(ProductApparelDataModel model)
        {
            var entity = _mappingUtility.Map<ProductApparelDataModel, ProductApparelModel>(model);
            if (entity != null)
            {
                entity.Product = _mappingUtility.Map<ProductApparelDataModel, ProductModel>(model);
                _productApparelRepository.Insert(entity);
                return _unitOfWork.Commit() > 0;
            }
            return false;
        }

        public bool Update(int id, ProductApparelDataModel model)
        {
            var availableEntity = _productApparelRepository.GetById(id);
            var entity = _mappingUtility.Map<ProductApparelDataModel, ProductApparelModel>(model, availableEntity);
            if (entity != null)
            {
                entity.Product = _mappingUtility.Map<ProductApparelDataModel, ProductModel>(model, availableEntity.Product);
                _productApparelRepository.Update(entity);
                return _unitOfWork.Commit() > 0;
            }
            return false;
        }
    }
}