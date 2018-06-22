using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductTypeModel : IBaseEntity
    {
        public ProductTypeModel()
        {
            Products = new List<ProductModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }
}