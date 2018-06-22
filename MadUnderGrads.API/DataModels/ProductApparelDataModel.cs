using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ProductApparelDataModel : BaseProductModel
    {
        public string Material { get; set; }
        public string Size { get; set; }
        public bool AvailableForMen { get; set; }
        public bool AvailableForWomen { get; set; }
    }
}