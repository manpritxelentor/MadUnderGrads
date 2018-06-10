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
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IHttpActionResult Get()
        {
            var data = categoryService.GetAll();
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
