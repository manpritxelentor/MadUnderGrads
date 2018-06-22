using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class BaseProductModel : IBaseModel
    {
        public BaseProductModel()
        {
            Pictures = new List<PictureDataModel>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsNegotiable { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }
        public bool IsSold { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? ProductTypeId { get; set; }
        public virtual ProductTypeDataModel ProductType { get; set; }
        public UserDataModel UserDto { get; set; }
        public List<PictureDataModel> Pictures { get; set; }
    }
}