using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Kae.Utility.Logging
{
    public class DebugLogger : Logger
    {
        protected static Logger logger;
        public static Logger CreateLogger()
        {
            if (logger == null)
            {
                logger = new DebugLogger() { ShowLevel = Level.Info };
            }
            return logger;
        }

        protected override async Task LogInternal(Level level, string log, string timestamp)
        {
            Debug.WriteLine($"[{level}]{timestamp}: {log}");
        }
    }
}
