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
    [RoutePrefix("api/Event")]
    public class EventController : BaseApiController
    {
        private readonly IEventService eventService;
        private readonly IIdentityHelper identityHelper;

        public EventController(IEventService eventService
            , IIdentityHelper identityHelper)
        {
            this.eventService = eventService;
            this.identityHelper = identityHelper;
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(EventDataModel model)
        {
            var data = eventService.Add(model, identityHelper.UserId);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        [Route("Update/{id}")]
        [HttpPost]
        public IHttpActionResult Update(int id, EventDataModel model)
        {
            var data = eventService.Update(id, model, identityHelper.UserId);
            if (data == null)
                return InternalServerError();
            return Ok(data);
        }

        [Route("Get")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = eventService.GetActiveEvents();
            if (data == null || !data.Any())
                return NotFound();
            return Ok(data);
        }

        [Route("GetByDate/{startDate?}/{endDate?}")]
        [HttpGet]
        public IHttpActionResult GetByDate(DateTime? startDate = null, DateTime? endDate = null)
        {
            var data = eventService.GetEventByDate(startDate, endDate);
            if (data == null || !data.Any())
                return NotFound();
            return Ok(data);
        }

        [Route("GetEventUsers/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetEventUsers(int eventId)
        {
            var data = eventService.GetEventUsers(eventId);
            if (data == null || !data.Any())
                return NotFound();
            return Ok(data);
        }

        [Route("GetById/{eventId}")]
        [HttpGet]
        public IHttpActionResult GetById(int eventId)
        {
            var data = eventService.GetById(eventId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("AttendEvent/{attendingLevel}/{eventId}")]
        [HttpPost]
        public IHttpActionResult AttendEvent(AttendingLevelType attendingLevel, int eventId)
        {
            var isSaved = eventService.AttendEvent(attendingLevel, eventId, identityHelper.UserId);
            if (!isSaved)
                return NotFound();
            return Ok(isSaved);
        }
    }
}
