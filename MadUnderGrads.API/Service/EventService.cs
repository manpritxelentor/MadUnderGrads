using MadUnderGrads.API.DataModels;
using MadUnderGrads.API.Models;
using MadUnderGrads.API.Repository;
using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Service
{
    public interface IEventService
    {
        EventDataModel Add(EventDataModel model, string userId);
        EventDataModel Update(int id, EventDataModel model, string userId);
        IEnumerable<EventDataModel> GetActiveEvents();
        IEnumerable<EventDataModel> GetEventByDate(DateTime? fromDate, DateTime? toDate);
        IEnumerable<UserDataModel> GetEventUsers(int eventId);
        EventDataModel GetById(int id);
        bool AttendEvent(AttendingLevelType level, int eventId, string userId);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        private readonly IMappingUtility mappingUtility;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IEventRepository eventRepository
            , IMappingUtility mappingUtility
            , IUnitOfWork unitOfWork)
        {
            this.eventRepository = eventRepository;
            this.mappingUtility = mappingUtility;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<EventDataModel> GetActiveEvents()
        {
            return mappingUtility.Project<EventModel, EventDataModel>(
                eventRepository.GetActiveEvents()).ToList();
        }

        public IEnumerable<EventDataModel> GetEventByDate(DateTime? fromDate, DateTime? toDate)
        {
            return mappingUtility.Project<EventModel, EventDataModel>(
                eventRepository.GetEventByDate(fromDate, toDate));
        }

        public IEnumerable<UserDataModel> GetEventUsers(int eventId)
        {
            return mappingUtility.Project<ApplicationUser, UserDataModel>(
                eventRepository.GetEventUsers(eventId));
        }

        public EventDataModel GetById(int id)
        {
            var data = eventRepository.GetById(id);
            if (data == null)
                return null;
            return mappingUtility.Map<EventModel, EventDataModel>(data);
        }

        public bool AttendEvent(AttendingLevelType level, int eventId, string userId)
        {
            var model = eventRepository.GetUserEvent(eventId, userId);
            if (model == null)
            {
                model = eventRepository.CreateUserEventEntity();
                model.CreatedOn = DateTime.Now;
                model.EventId = eventId;
                model.UserId = userId;
                model.AttendingLevel = level;
                eventRepository.AddUserEvent(model);
            }
            else
            {
                model.ModifiedOn = DateTime.Now;
                model.AttendingLevel = level;
                eventRepository.UpdateUserEvent(model);
            }
            return unitOfWork.Commit() > 0;
        }

        public EventDataModel Add(EventDataModel model, string userId)
        {
            var entity = eventRepository.Create();
            mappingUtility.Map<EventDataModel, EventModel>(model,entity);
            entity.CreatedBy = userId;
            entity.CreatedOn = DateTime.Now;
            entity.IsActive = true;
            eventRepository.Insert(entity);
            bool isSaved = unitOfWork.Commit() > 0;
            if (isSaved)
                return GetById(entity.Id);
            return null;
        }

        public EventDataModel Update(int id, EventDataModel model, string userId)
        {
            var entity = eventRepository.GetById(id);
            if (entity == null)
                return null;
            mappingUtility.Map<EventDataModel, EventModel>(model, entity);
            entity.ModifiedBy = userId;
            entity.ModifiedOn = DateTime.Now;
            eventRepository.Update(entity);
            bool isSaved = unitOfWork.Commit() > 0;
            if (isSaved)
                return GetById(id);
            return null;
        }
    }
}