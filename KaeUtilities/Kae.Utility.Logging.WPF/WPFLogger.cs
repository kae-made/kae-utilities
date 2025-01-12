using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kae.Utility.Logging.WPF
{
    public class WPFLogger : Logger
    {
        protected static WPFLogger logger;


        public static Logger CreateLogger(TextBlock logBlock)
        {
            if (logger == null)
            {
                logger = new WPFLogger(logBlock) { ShowLevel = Level.Info };
            }
            else
            {
                logger.logBlock = logBlock;
            }
            return logger;
        }

        protected TextBlock logBlock;

        protected WPFLogger(TextBlock logBlock)
        {
            this.logBlock = logBlock;
        }

        protected override async Task LogInternal(Level level, string log, string timestamp, Exception ex)
        {
            await logBlock.Dispatcher.Invoke(async () =>
            {
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);
                await writer.WriteLineAsync($"{level.ToString()}:{timestamp} {log}");
                if (ex != null)
                {
                    await writer.WriteLineAsync("Exception : ");
                    await writer.WriteAsync(ex.Message);
                    await writer.WriteLineAsync();
                }
                await writer.WriteLineAsync(logBlock.Text);
                logBlock.Text = sb.ToString();
            });
        }
    }
}
