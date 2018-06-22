using MadUnderGrads.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Repository
{
    public interface IEventRepository : IGenericRepository<EventModel>
    {
        IQueryable<EventModel> GetActiveEvents();
        IQueryable<EventModel> GetEventByDate(DateTime? fromDate, DateTime? toDate);
        IQueryable<ApplicationUser> GetEventUsers(int eventId);
        EventUserModel GetUserEvent(int eventId, string userId);
        EventUserModel CreateUserEventEntity();
        void UpdateUserEvent(EventUserModel model);
        void AddUserEvent(EventUserModel model);
    }


    public class EventRepository : EfGenericRepository<EventModel>, IEventRepository
    {
        private readonly IDataContext dataContext;
        public EventRepository(IDataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddUserEvent(EventUserModel model)
        {
            dataContext.Insert<EventUserModel>(model);
        }

        public EventUserModel CreateUserEventEntity()
        {
            return dataContext.Create<EventUserModel>();
        }

        public IQueryable<EventModel> GetActiveEvents()
        {
            return GetAllNoTracking().Where(w => w.IsActive)
                .OrderBy(w => w.EventDate)
                .ThenBy(w => w.IsFeatured);
        }

        public IQueryable<EventModel> GetEventByDate(DateTime? fromDate, DateTime? toDate)
        {
            return GetAllNoTracking()
                .Where(w => w.IsActive
                && (fromDate == null || DbFunctions.TruncateTime(fromDate) >= DbFunctions.TruncateTime(w.EventDate))
                && (toDate == null || DbFunctions.TruncateTime(toDate) <= DbFunctions.TruncateTime(w.EventDate))
                )
                .OrderBy(w => w.EventDate)
                .ThenBy(w => w.IsFeatured);
        }

        public IQueryable<ApplicationUser> GetEventUsers(int eventId)
        {
            return dataContext.EntitiesNoTracking<EventUserModel>()
                .Where(w => w.EventId == eventId)
                .Select(w => w.User);
        }

        public EventUserModel GetUserEvent(int eventId, string userId)
        {
            return dataContext.EntitiesNoTracking<EventUserModel>()
                .Where(w => w.UserId == userId && w.EventId == eventId)
                .FirstOrDefault();
        }

        public void UpdateUserEvent(EventUserModel model)
        {
            dataContext.Update<EventUserModel>(model);
        }
    }
}