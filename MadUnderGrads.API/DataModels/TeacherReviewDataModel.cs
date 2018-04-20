using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class TeacherReviewDataModel : IBaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public int TeacherId { get; set; }
    }
}