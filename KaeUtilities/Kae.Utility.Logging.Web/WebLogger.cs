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
        protected override async Task LogInternal(Level level, string log, string timestamp, Exception ex)
        {
            string logMsg = $"{log} @ {timestamp}";
            if (level== Level.Info)
            {
                logger.LogInfo(logMsg);
            }
            else if (level== Level.Warn)
            {
                logger.LogWarning(logMsg);
            }
            else if (level== Level.Erro)
            {
                logger.LogError($"exception - {ex.Message}");
                logger.LogError(logMsg);
            }
            else
            {
                if (ex != null)
                {
                    logger.LogError($"exception - {ex.Message}");
                }
                logger.LogError(logMsg);
            }
        }
    }
}