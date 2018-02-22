using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductElectronicsModel : IBaseEntity
    {
        public int ProductId { get; set; }
        public string Manufacturer { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}