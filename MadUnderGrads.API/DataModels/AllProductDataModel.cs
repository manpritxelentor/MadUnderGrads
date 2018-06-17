using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class AllProductDataModel : IBaseModel
    {
        // Product properties
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string Description { get; set; }
        public bool IsNegotiable { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }
        public bool IsSold { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Textbook properties
        public string ISBN { get; set; }
        public string Title { get; set; }
        public bool NotesIncluded { get; set; }

        public UserDataModel UserDto { get; set; }
    }
}