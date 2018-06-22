using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class EventModel : IBaseEntity
    {
        public EventModel()
        {
            EventUsers = new List<EventUserModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? PictureId { get; set; }

        public virtual PictureModel Picture { get; set; }
        public virtual ICollection<EventUserModel> EventUsers { get; set; }
    }
}