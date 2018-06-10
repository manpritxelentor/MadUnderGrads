using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class BaseProductModel : IBaseModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}