using MadUnderGrads.API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class EventUserModel : IBaseEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public AttendingLevelType AttendingLevel { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }


        public virtual EventModel Event { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}