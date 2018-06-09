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
