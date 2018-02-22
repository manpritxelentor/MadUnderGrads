using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductApparelModel:IBaseEntity
    {
        public int ProductId { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public bool AvailableForMen { get; set; }
        public bool AvailableForWomen { get; set; }
        public virtual ProductModel Product { get; set; }
        
    }
}