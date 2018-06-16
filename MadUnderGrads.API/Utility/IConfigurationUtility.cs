using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Utility
{
    public interface IConfigurationUtility
    {
        bool IsDevelopmentMode { get; }
    }

    public class ConfigurationUtility : IConfigurationUtility
    {
        public bool IsDevelopmentMode => Convert.ToBoolean(ConfigurationManager.AppSettings["DevelopmentMode"]);
    }
}