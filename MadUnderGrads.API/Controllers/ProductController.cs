using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Service;
using MadUnderGrads.API.Utility;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace MadUnderGrads.API.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService productService;
        private readonly IIdentityHelper identityHelper;

        public ProductController(IProductService productService
            , IIdentityHelper identityHelper)
        {
            this.productService = productService;
            this.identityHelper = identityHelper;
        }

        [Route("Get/{categoryCode}")]
        public IHttpActionResult Get(string categoryCode)
        {
            IEnumerable<BaseProductModel> baseProductModels = productService.GetProducts(categoryCode);
            if (baseProductModels == null)
                return NotFound();
            return Ok(baseProductModels);
        }

        [Route("GetById/{productId}")]
        public IHttpActionResult GetById(int productId)
        {
            var baseProductModel = productService.GetById(productId);
            if (baseProductModel == null)
                return NotFound();
            return Ok(baseProductModel);
        }

        [Route("GetMyProducts/{categoryCode?}")]
        [AllowAnonymous]
        public IHttpActionResult GetMyProducts(string categoryCode = null)
        {
            var baseProductModels = productService.GetMyProducts(categoryCode, identityHelper.UserId);
            if (baseProductModels == null)
                return NotFound();
            return Ok(baseProductModels);
        }

        [HttpPost]
        [Route("SellProduct/{productId}")]
        public IHttpActionResult SellProduct(int productId)
        {
            bool isSaved = productService.SellProduct(productId, identityHelper.UserId);
            if (!isSaved)
                return InternalServerError();
            return Ok(isSaved);
        }

        [HttpPost]
        [Route("Delete/{productId}")]
        public IHttpActionResult Delete(int productId)
        {
            bool isDeleted = productService.Delete(productId);
            if (!isDeleted)
                return InternalServerError();
            return Ok(isDeleted);
        }

        [HttpPost]
        [Route("UploadImage/{productId}")]
        public IHttpActionResult UploadImage(int productId)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var folderName = "UploadFile/";
                var serverPath = $"~/{folderName}";
                var path = HttpContext.Current.Server.MapPath(serverPath);
                Directory.CreateDirectory(path);
                List<string> pictures = new List<string>();

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = Path.Combine(path, postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    var dbFilePath = Path.Combine(folderName, postedFile.FileName);
                    pictures.Add(dbFilePath);
                }
                bool result = productService.UploadPicture(productId, pictures, identityHelper.UserId);
                return Ok(result);
            }
            return BadRequest("No file found for uploading");
        }

        [HttpPost]
        [Route("SearchProduct")]
        public IHttpActionResult SearchProduct(ProductSearchDataModel model)
        {
            return Ok();
        }

        #region TextBook Methods
        [HttpPost]
        [Route("Add/" + Constants.Category.TextBooks)]
        public IHttpActionResult AddTextBook(ProductTextBookDataModel model)
        {
            return AddProduct(model, Constants.Category.TextBooks);
        }

        [HttpPost]
        [Route("Update/" + Constants.Category.TextBooks + "/{productId}")]
        public IHttpActionResult UpdateTextBook(int productId, ProductTextBookDataModel model)
        {
            return UpdateProduct(productId, model, Constants.Category.TextBooks);
        }

        #endregion

        #region Apparel Methods
        [HttpPost]
        [Route("Add/" + Constants.Category.Apparel)]
        public IHttpActionResult AddApprarel(ProductApparelDataModel model)
        {
            return AddProduct(model, Constants.Category.Apparel);
        }

        [HttpPost]
        [Route("Update/" + Constants.Category.Apparel + "/{productId}")]
        public IHttpActionResult UpdateApprarel(int productId, ProductApparelDataModel model)
        {
            return UpdateProduct(productId, model, Constants.Category.Apparel);
        }
        #endregion

        #region Electronics
        [HttpPost]
        [Route("Add/" + Constants.Category.Electronics)]
        public IHttpActionResult AddElectronics(ProductElectronicsDataModel model)
        {
            return AddProduct(model, Constants.Category.Electronics);
        }

        [HttpPost]
        [Route("Update/" + Constants.Category.Electronics + "/{productId}")]
        public IHttpActionResult UpdateElectronics(int productId, ProductElectronicsDataModel model)
        {
            return UpdateProduct(productId, model, Constants.Category.Electronics);
        }
        #endregion

        #region Furniture
        [HttpPost]
        [Route("Add/" + Constants.Category.Furniture)]
        public IHttpActionResult AddFurniture(ProductFurnitureDataModel model)
        {
            return AddProduct(model, Constants.Category.Furniture);
        }

        [HttpPost]
        [Route("Update/" + Constants.Category.Furniture + "/{productId}")]
        public IHttpActionResult UpdateFurniture(int productId, ProductFurnitureDataModel model)
        {
            return UpdateProduct(productId, model, Constants.Category.Furniture);
        }
        #endregion

        #region Miscellenous
        [HttpPost]
        [Route("Add/" + Constants.Category.Miscellanous)]
        public IHttpActionResult AddMisellanous(ProductMisellanousDataModel model)
        {
            return AddProduct(model, Constants.Category.Miscellanous);
        }

        [HttpPost]
        [Route("Update/" + Constants.Category.Miscellanous + "/{productId}")]
        public IHttpActionResult UpdateMisellanous(int productId, ProductMisellanousDataModel model)
        {
            return UpdateProduct(productId, model, Constants.Category.Miscellanous);
        }
        #endregion

        #region Helpers
        private IHttpActionResult AddProduct(BaseProductModel model, string categoryCode)
        {
            var data = productService.Insert(model, identityHelper.UserId, categoryCode);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        private IHttpActionResult UpdateProduct(int productId, BaseProductModel model, string categoryCode)
        {
            var data = productService.Update(productId, model, identityHelper.UserId, categoryCode);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }
        #endregion
    }
}
