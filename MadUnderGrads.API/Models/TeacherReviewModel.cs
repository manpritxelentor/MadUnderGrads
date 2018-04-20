using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class TeacherReviewModel : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public int TeacherId { get; set; }
        public string Reviewer { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual TeacherModel Teacher { get; set; }
    }
}