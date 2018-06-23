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
        IEnumerable<AllProductDataModel> GetMyProducts(string categoryCode, string userId);
        bool SellProduct(int productId, string userId);
        bool Delete(int productId);
        BaseProductModel Insert(BaseProductModel model, string userId, string categoryCode);
        BaseProductModel Update(int id, BaseProductModel model, string userId, string categoryCode);
    }

    public class ProductService : IProductService
    {
        #region Private Variables
        private readonly IProductRepository productRepository;
        private readonly IPictureRepository pictureRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingUtility mappingUtility;
        private readonly ICategoryRepository categoryRepository;
        #endregion

        #region Constructors
        public ProductService(IProductRepository productRepository
           , IPictureRepository pictureRepository
           , IUnitOfWork unitOfWork
           , IMappingUtility mappingUtility
           , ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.pictureRepository = pictureRepository;
            this.unitOfWork = unitOfWork;
            this.mappingUtility = mappingUtility;
            this.categoryRepository = categoryRepository;
        }
        #endregion

        #region Public Methods
        public IEnumerable<BaseProductModel> GetProducts(string categoryCode)
        {
            var data = productRepository.GetbyCategory(categoryCode);
            return MapProductToDto(categoryCode, data);
        }

        public IEnumerable<AllProductDataModel> GetMyProducts(string categoryCode, string userId)
        {
            var productData = productRepository.GetByUserAndCategory(categoryCode, userId).ToList();
            if (productData == null || !productData.Any())
                return null;
            var data = productData.Select(s =>
           {
               var productMap = mappingUtility.Map<ProductModel, AllProductDataModel>(s);
               productMap = MapProductChildCategory(productMap.CategoryCode, s, productMap);
               return productMap;
           }).ToList();
            return data;
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

        public BaseProductModel Insert(BaseProductModel model, string userId, string categoryCode)
        {
            ProductModel entity = MapDtoToProduct(model, productRepository.Create());
            entity.CreatedBy = userId;
            entity.CreatedOn = DateTime.Now;
            entity.CategoryId = categoryRepository.GetCategoryIdByCode(categoryCode);
            productRepository.Insert(entity);
            bool isSaved = unitOfWork.Commit() > 0;
            if (isSaved)
                return GetById(entity.Id);
            return null;
        }

        public BaseProductModel Update(int id, BaseProductModel model, string userId, string categoryCode)
        {
            var entity = productRepository.GetById(id);
            MapDtoToProduct(model, entity);
            entity.UpdatedBy = userId;
            entity.UpdatedOn = DateTime.Now;
            entity.CategoryId = categoryRepository.GetCategoryIdByCode(categoryCode);
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
                case Constants.Category.Apparel:
                    return mappingUtility.Map<ProductModel, ProductApparelDataModel>(data);
                case Constants.Category.Electronics:
                    return mappingUtility.Map<ProductModel, ProductElectronicsDataModel>(data);
                case Constants.Category.Furniture:
                    return mappingUtility.Map<ProductModel, ProductFurnitureDataModel>(data);
                case Constants.Category.Miscellanous:
                    return mappingUtility.Map<ProductModel, ProductMisellanousDataModel>(data);
            }
            return null;
        }

        private IEnumerable<BaseProductModel> MapProductToDto(string categoryCode, IQueryable<ProductModel> data)
        {
            switch (categoryCode)
            {
                case Constants.Category.TextBooks:
                    return mappingUtility.Project<ProductModel, ProductTextBookDataModel>(data).ToList();
                case Constants.Category.Apparel:
                    return mappingUtility.Project<ProductModel, ProductApparelDataModel>(data).ToList();
                case Constants.Category.Electronics:
                    return mappingUtility.Project<ProductModel, ProductElectronicsDataModel>(data).ToList();
                case Constants.Category.Furniture:
                    return mappingUtility.Project<ProductModel, ProductFurnitureDataModel>(data).ToList();
                case Constants.Category.Miscellanous:
                    return mappingUtility.Project<ProductModel, ProductMisellanousDataModel>(data).ToList();
            }
            return null;
        }

        private AllProductDataModel MapProductChildCategory(string categoryCode, ProductModel s, AllProductDataModel productMap)
        {
            switch (categoryCode)
            {
                case Constants.Category.TextBooks:
                    return mappingUtility.Map<ProductTextbookModel, AllProductDataModel>(s.ProductTextbooks, productMap);
                case Constants.Category.Apparel:
                    return mappingUtility.Map<ProductApparelModel, AllProductDataModel>(s.ProductApparels, productMap);
                case Constants.Category.Electronics:
                    return mappingUtility.Map<ProductElectronicsModel, AllProductDataModel>(s.ProductElectronics, productMap);
                case Constants.Category.Furniture:
                    return mappingUtility.Map<ProductFurnitureModel, AllProductDataModel>(s.ProductFurniture, productMap);
                case Constants.Category.Miscellanous:
                    return mappingUtility.Map<ProductMisellanousModel, AllProductDataModel>(s.ProductMisellanous, productMap);
            }
            return productMap;
        }

        private ProductModel MapDtoToProduct<T>(T data, ProductModel entity)
            where T : BaseProductModel
        {
            return mappingUtility.Map<T, ProductModel>(data, entity);
        }
        #endregion
    }
}