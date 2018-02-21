using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace MadUnderGrads.API.Filters
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        private readonly ILog _logger;
        public GlobalExceptionLogger()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Error("Global Error", context.Exception);
        }
    }
}