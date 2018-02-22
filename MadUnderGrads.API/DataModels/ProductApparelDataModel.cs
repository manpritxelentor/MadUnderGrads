using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ProductApparelDataModel : IBaseModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNegotiable { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public bool AvailableForMen { get; set; }
        public bool AvailableForWomen { get; set; }
        public string Condition { get; set; }
    }
}