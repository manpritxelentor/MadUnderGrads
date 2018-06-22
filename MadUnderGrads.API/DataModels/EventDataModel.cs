using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class EventDataModel : IBaseModel
    {
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

        public int AttedingUserCount { get; set; }
        public PictureDataModel Picture { get; set; }
    }
}