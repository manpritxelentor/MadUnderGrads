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
    public interface IProductService
    {
        bool UploadPicture(int productId, List<string> pictures, string userId);
        IEnumerable<BaseProductModel> GetProducts(string categoryCode);
        BaseProductModel GetById(int productId);
        IEnumerable<BaseProductModel> GetMyProducts(string categoryCode, string userId);
        bool SellProduct(int productId, string userId);
        bool Delete(int productId);
        BaseProductModel Insert(BaseProductModel model, string userId);
        BaseProductModel Update(int id, BaseProductModel model, string userId);
    }

    public class ProductService : IProductService
    {
        #region Private Variables
        private readonly IProductRepository productRepository;
        private readonly IPictureRepository pictureRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingUtility mappingUtility;
        #endregion

        #region Constructors
        public ProductService(IProductRepository productRepository
           , IPictureRepository pictureRepository
           , IUnitOfWork unitOfWork
           , IMappingUtility mappingUtility)
        {
            this.productRepository = productRepository;
            this.pictureRepository = pictureRepository;
            this.unitOfWork = unitOfWork;
            this.mappingUtility = mappingUtility;
        }
        #endregion

        #region Public Methods
        public IEnumerable<BaseProductModel> GetProducts(string categoryCode)
        {
            var data = productRepository.GetbyCategory(categoryCode);
            return MapProductToDto(categoryCode, data);
        }

        public IEnumerable<BaseProductModel> GetMyProducts(string categoryCode, string userId)
        {
            var data = productRepository.GetByUserAndCategory(categoryCode, userId);
            return MapProductToDto(categoryCode, data);
        }

        public BaseProductModel GetById(int productId)
        {
            var data = productRepository.GetById(productId);
            if (data == null)
                return null;
            return MapProductToDto(data.Category.Code, data);
        }

        public bool UploadPicture(int productId, List<string> pictures, string userId)
        {
            var data = productRepository.GetById(productId);
            pictures.ForEach(path => data.Pictures.Add(new Models.PictureModel
            {
                Path = path,
                CreatedOn = DateTime.Now,
            }));
            data.UpdatedBy = userId;
            data.UpdatedOn = DateTime.Now;
            productRepository.Update(data);
            return unitOfWork.Commit() > 0;
        }

        public bool SellProduct(int productId, string userId)
        {
            var data = productRepository.GetById(productId);
            if (data == null)
                return false;

            data.IsSold = true;
            data.UpdatedBy = userId;
            data.UpdatedOn = DateTime.Now;

            return unitOfWork.Commit() > 0;
        }

        public bool Delete(int productId)
        {
            productRepository.DeleteById(productId);
            return unitOfWork.Commit() > 0;
        }

        public BaseProductModel Insert(BaseProductModel model, string userId)
        {
            ProductModel entity = MapDtoToProduct(model, productRepository.Create());
            entity.CreatedBy = userId;
            entity.CreatedOn = DateTime.Now;
            productRepository.Insert(entity);
            bool isSaved = unitOfWork.Commit() > 0;
            if (isSaved)
                return GetById(entity.Id);
            return null;
        }

        public BaseProductModel Update(int id, BaseProductModel model, string userId)
        {
            var entity = productRepository.GetById(id);
            MapDtoToProduct(model, entity);
            entity.UpdatedBy = userId;
            entity.UpdatedOn = DateTime.Now;
            productRepository.Update(entity);
            bool isSaved = unitOfWork.Commit() > 0;
            if (isSaved)
                return GetById(entity.Id);
            return null;
        }
        #endregion

        #region Helper Methods
        private BaseProductModel MapProductToDto(string categoryCode, ProductModel data)
        {
            switch (categoryCode)
            {
                case Constants.Category.TextBooks:
                    return mappingUtility.Map<ProductModel, ProductTextBookDataModel>(data);
            }
            return null;
        }

        private IEnumerable<BaseProductModel> MapProductToDto(string categoryCode, IQueryable<ProductModel> data)
        {
            switch (categoryCode)
            {
                case Constants.Category.TextBooks:
                    return mappingUtility.Project<ProductModel, ProductTextBookDataModel>(data).ToList();
            }
            return null;
        }

        private ProductModel MapDtoToProduct<T>(T data, ProductModel entity)
            where T : BaseProductModel
        {
            return mappingUtility.Map<T, ProductModel>(data, entity);
        }
        #endregion
    }
}