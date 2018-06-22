using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductModel : IBaseEntity
    {
        public ProductModel()
        {
            Pictures = new List<PictureModel>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsNegotiable { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }
        public bool IsSold { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? ProductTypeId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ProductTextbookModel ProductTextbooks { get; set; }
        public virtual ProductApparelModel ProductApparels { get; set; }
        public virtual ProductElectronicsModel ProductElectronics { get; set; }
        public virtual ProductFurnitureModel ProductFurniture { get; set; }
        public virtual ProductMisellanousModel ProductMisellanous { get; set; }
        public virtual ICollection<PictureModel> Pictures { get; set; }


        public virtual ApplicationUser Creator { get; set; }
        public virtual ApplicationUser Updator { get; set; }
        public virtual ProductTypeModel ProductType { get; set; }
    }
}