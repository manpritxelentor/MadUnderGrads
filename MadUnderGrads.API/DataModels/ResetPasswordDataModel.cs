﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.DataModels
{
    public class ResetPasswordDataModel
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}