using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ConfirmEmailDataModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}