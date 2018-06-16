using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class CategoryModel : IBaseEntity
    {
        public CategoryModel()
        {
            Products = new List<ProductModel>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}