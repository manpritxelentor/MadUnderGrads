﻿using MadUnderGrads.API.DataModels;
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
    [RoutePrefix("api/TeacherReview")]
    public class TeacherReviewController : BaseApiController
    {
        private readonly ITeacherReviewService teacherReviewService;
        private readonly IIdentityHelper identityHelper;
        public TeacherReviewController(ITeacherReviewService teacherReviewService
            , IIdentityHelper identityHelper)
        {
            this.teacherReviewService = teacherReviewService;
            this.identityHelper = identityHelper;
        }

        public IHttpActionResult Get()
        {
            var data = teacherReviewService.GetAll();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetByTeacherId/{teacherId}")]
        public IHttpActionResult GetByTeacherId(int teacherId)
        {
            var data = teacherReviewService.GetByTeacherId(teacherId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Get(int id)
        {
            var data = teacherReviewService.GetById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult Delete(int id)
        {
            var data = teacherReviewService.Delete(id);
            return Ok(data);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]TeacherReviewDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = teacherReviewService.Insert(model, identityHelper.UserId);
            if (result == null)
                return InternalServerError();
            return Ok(result);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]TeacherReviewDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = teacherReviewService.Update(model, identityHelper.UserId);
            if (result == null)
                return InternalServerError();
            return Ok(result);
        }
    }
}
