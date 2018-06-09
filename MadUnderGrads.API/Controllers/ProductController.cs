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
        [HttpPost]
        [Route("UploadImage")]
        public IHttpActionResult UploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var serverPath = "~/UploadFile/";
                var path = HttpContext.Current.Server.MapPath(serverPath);
                Directory.CreateDirectory(path);
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = Path.Combine(path,postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    var dbFilePath = Path.Combine(serverPath, postedFile.FileName);

                }
                return Ok();
            }
            return BadRequest("No file found for uploading");
        }

    }
}
