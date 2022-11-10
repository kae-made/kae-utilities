using Microsoft.Extensions.Logging;

namespace Kae.Utility.Logging.Web
{
    public class WebLogger : Logger
    {
        protected static WebLogger logger;

        public Logger CreateLogger(ILogger log)
        {
            if (logger == null)
            {
                logger = new WebLogger(log);
            }
            else
            {
                logger.webLog = log;
            }
            return logger;
        }

        protected ILogger webLog;
        protected WebLogger(ILogger webLog)
        {
            this.webLog = webLog;
        }
        protected override Task LogInternal(Level level, string log, string timestamp)
        {
            throw new NotImplementedException();
        }
    }
}