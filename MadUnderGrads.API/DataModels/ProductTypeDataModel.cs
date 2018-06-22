using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ProductTypeDataModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
}