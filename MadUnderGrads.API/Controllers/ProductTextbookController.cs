using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MadUnderGrads.API.Controllers
{
    public class ProductTextbookController : BaseApiController
    {
        private readonly IProductTextBookService _productTextBookService;

        // Test changes
        public ProductTextbookController(IProductTextBookService productTextBookService)
        {
            _productTextBookService = productTextBookService;
        }

        public IHttpActionResult Get()
        {
            var data = _productTextBookService.GetAll();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Get(int id)
        {
            var data = _productTextBookService.GetById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Delete(int id)
        {
            var data = _productTextBookService.Delete(id);
            return Ok(data);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]ProductTextBookDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = _productTextBookService.Insert(model);
            return Ok(result);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]ProductTextBookDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = _productTextBookService.Update(id, model);
            return Ok(result);
        }
    }
}
