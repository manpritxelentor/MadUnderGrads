using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class TeacherDataModel : IBaseModel
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public string ProfessorName { get; set; }
        public string SchoolName { get; set; }
        public string ClassCourse { get; set; }

    }
}