using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Service;
using MadUnderGrads.API.Utility;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MadUnderGrads.API.Controllers
{
    public class TeacherController : BaseApiController
    {
        private readonly ITeacherService teacherService;
        private readonly IIdentityHelper identityHelper;

        public TeacherController(ITeacherService teacherService
            , IIdentityHelper identityHelper)
        {
            this.teacherService = teacherService;
            this.identityHelper = identityHelper;
        }

        public IHttpActionResult Get()
        {
            var data = teacherService.GetAll();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Get(int id)
        {
            var data = teacherService.GetById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Delete(int id)
        {
            var data = teacherService.Delete(id, identityHelper.UserId);
            return Ok(data);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]TeacherDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = teacherService.Insert(model, identityHelper.UserId);
            return Ok(result);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]TeacherDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = teacherService.Update(model, identityHelper.UserId);
            return Ok(result);
        }
    }
}
