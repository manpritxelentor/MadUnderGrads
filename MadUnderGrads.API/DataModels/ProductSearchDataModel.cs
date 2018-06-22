using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ProductSearchDataModel
    {
        public string Title { get; set; }
        public int? ProductTypeId { get; set; }
        public string ProductType { get; set; }
        public string Category { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}