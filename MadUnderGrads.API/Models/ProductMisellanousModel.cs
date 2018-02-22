using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductMisellanousModel : IBaseEntity
    {
        public int ProductId { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}