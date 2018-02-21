using FluentValidation.Attributes;
using MadUnderGrads.API.DataModels.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    [Validator(typeof(ProductTextBookDataModelValidator))]
    public class ProductTextBookDataModel : IBaseModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNegotiable { get; set; }
        public decimal Price { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public bool NotesIncluded { get; set; }
        public string Condition { get; set; }
    }
}