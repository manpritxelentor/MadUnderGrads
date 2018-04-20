using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Utility
{
    public interface IIdentityHelper
    {
        string UserId { get; }
    }

    public class IdentityHelper : IIdentityHelper
    {
        public string UserId => HttpContext.Current.User.Identity.GetUserId<string>();
    }
}