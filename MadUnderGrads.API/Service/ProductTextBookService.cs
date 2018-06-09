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
    public interface IProductTextBookService
    {
        IEnumerable<ProductTextBookDataModel> GetAll();
        ProductTextBookDataModel GetById(int id);
        bool Delete(int id);
        bool Insert(ProductTextBookDataModel model, string userId);
        bool Update(int id, ProductTextBookDataModel model, string userId);
    }

    public class ProductTextBookService : IProductTextBookService
    {
        private readonly IProductTextBookRepository _productTextBookRepository;
        private readonly IMappingUtility _mappingUtility;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTextBookService(IProductTextBookRepository productTextBookRepository
            , IMappingUtility mappingUtility
            , IUnitOfWork unitOfWork)
        {
            _productTextBookRepository = productTextBookRepository;
            _mappingUtility = mappingUtility;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductTextBookDataModel> GetAll()
        {
            return _mappingUtility
                .Project<ProductTextbookModel, ProductTextBookDataModel>(
                _productTextBookRepository.GetAll())
                .ToList();
        }

        public ProductTextBookDataModel GetById(int id)
        {
            var data = _productTextBookRepository.GetById(id);
            if (data == null)
                return null;
            return _mappingUtility.Map<ProductTextbookModel, ProductTextBookDataModel>(data);
        }

        public bool Delete(int id)
        {
            _productTextBookRepository.DeleteById(id);
            return _unitOfWork.Commit() > 0;
        }

        public bool Insert(ProductTextBookDataModel model, string userId)
        {
            
            var entity = _mappingUtility.Map<ProductTextBookDataModel, ProductTextbookModel>(model);
            if (entity != null)
            {
                entity.Product = _mappingUtility.Map<ProductTextBookDataModel, ProductModel>(model);
                entity.Product.CreatedBy = userId;
                entity.Product.CreatedOn = DateTime.Now;
                _productTextBookRepository.Insert(entity);
                return _unitOfWork.Commit() > 0;
            }
            return false;
        }

        public bool Update(int id, ProductTextBookDataModel model, string userId)
        {
            var availableEntity = _productTextBookRepository.GetById(id);
            var entity = _mappingUtility.Map<ProductTextBookDataModel, ProductTextbookModel>(model, availableEntity);
            if (entity != null)
            {
                entity.Product = _mappingUtility.Map<ProductTextBookDataModel, ProductModel>(model, availableEntity.Product);
                entity.Product.UpdatedBy = userId;
                entity.Product.UpdatedOn = DateTime.Now;
                _productTextBookRepository.Update(entity);
                return _unitOfWork.Commit() > 0;
            }
            return false;
        }
    }
}