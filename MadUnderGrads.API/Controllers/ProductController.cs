using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Filters;
using MadUnderGrads.API.Service;
using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

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

        [Route("GetMyProducts/{categoryCode}")]
        public IHttpActionResult GetMyProducts(string categoryCode)
        {
            IEnumerable<BaseProductModel> baseProductModels = productService.GetMyProducts(categoryCode, identityHelper.UserId);
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
        [Route("Add/TxtBks")]
        public IHttpActionResult AddTextBook(ProductTextBookDataModel model)
        {
            var data = productService.Insert(model, identityHelper.UserId);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        [HttpPost]
        [Route("Update/TxtBks/{productId}")]
        public IHttpActionResult UpdateTextBook(int productId, ProductTextBookDataModel model)
        {
            var data = productService.Update(productId, model, identityHelper.UserId);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        [HttpPost]
        [Route("UploadImage/{productId}")]
        public IHttpActionResult UploadImage(int productId)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var serverPath = "~/UploadFile/";
                var path = HttpContext.Current.Server.MapPath(serverPath);
                Directory.CreateDirectory(path);
                List<string> pictures = new List<string>();

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = Path.Combine(path,postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    var dbFilePath = Path.Combine(serverPath, postedFile.FileName);
                    pictures.Add(dbFilePath);
                }
                bool result = productService.UploadPicture(productId, pictures, identityHelper.UserId);
                return Ok(result);
            }
            return BadRequest("No file found for uploading");
        }

    }
}
