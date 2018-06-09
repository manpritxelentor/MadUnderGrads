using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class TeacherModel : IBaseEntity
    {
        public TeacherModel()
        {
            Reviews = new List<TeacherReviewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfessorName { get; set; }
        public string SchoolName { get; set; }
        public string ClassCourse { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsApproved { get; set; }

        public virtual ICollection<TeacherReviewModel> Reviews { get; set; }
    }
}