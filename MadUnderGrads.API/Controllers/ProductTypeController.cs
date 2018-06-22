using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Service;
using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MadUnderGrads.API.Controllers
{
    [RoutePrefix("api/ProductType")]
    public class ProductTypeController : BaseApiController
    {
        private readonly IProductTypeService productTypeService;
        private readonly IIdentityHelper identityHelper;

        public ProductTypeController(IProductTypeService productTypeService
            , IIdentityHelper identityHelper)
        {
            this.productTypeService = productTypeService;
            this.identityHelper = identityHelper;
        }

        [HttpGet]
        [Route("GetByCategory/{categoryCode}")]
        public IHttpActionResult GetByCategory(string categoryCode)
        {
            var data = productTypeService.GetByCategory(categoryCode);
            if (data == null || !data.Any())
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var data = productTypeService.GetById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [Route("{categoryCode}/Add")]
        public IHttpActionResult Insert(string categoryCode, ProductTypeDataModel model)
        {
            var data = productTypeService.Insert(model, categoryCode, identityHelper.UserId);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        [HttpPost]
        [Route("{categoryCode}/Update/{productTypeId}")]
        public IHttpActionResult Update(string categoryCode, int productTypeId, ProductTypeDataModel model)
        {
            var data = productTypeService.Update(productTypeId, model, categoryCode, identityHelper.UserId);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        [HttpPost]
        [Route("{categoryCode}/Delete/{productTypeId}")]
        public IHttpActionResult Delete(string categoryCode, int productTypeId)
        {
            var isDeleted = productTypeService.Delete(productTypeId);
            if (!isDeleted)
                return InternalServerError();
            return Ok(isDeleted);
        }
    }
}
