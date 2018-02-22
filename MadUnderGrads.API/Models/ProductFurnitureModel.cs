using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductFurnitureModel : IBaseEntity
    {
        public int ProductId { get; set; }
        public string Type { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}