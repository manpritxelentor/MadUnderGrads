using MadUnderGrads.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Service
{
    public interface IProductService
    {
        bool UploadPicture(int productId, List<string> pictures, string userId);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IPictureRepository pictureRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository
            , IPictureRepository pictureRepository
            , IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.pictureRepository = pictureRepository;
            this.unitOfWork = unitOfWork;
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
    }
}