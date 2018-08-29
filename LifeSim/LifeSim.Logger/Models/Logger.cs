using System.Reflection;
using log4net;
using LifeSim.Logger.Contracts;

namespace LifeSim.Logger.Models
{
    public class Logger : ILogger
    {
        public Logger()
        {
            GetLogger = LogManager.GetLogger(MethodBase.GetCurrentMethod().GetType());
        }

        public ILog GetLogger { get; }
    }
}