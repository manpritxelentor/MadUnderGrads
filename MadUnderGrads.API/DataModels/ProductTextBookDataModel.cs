using FluentValidation.Attributes;
using MadUnderGrads.API.DataModels.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ProductTextBookDataModel : BaseProductModel
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public bool NotesIncluded { get; set; }
    }
                    
}