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
    public class SchoolController : BaseApiController
    {
        private readonly ITeacherService teacherService;

        public SchoolController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        public IHttpActionResult Get()
        {
            var data = teacherService.GetSchools();
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
