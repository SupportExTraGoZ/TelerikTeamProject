using System;
using LifeSim.Logger.Contracts;
using log4net.Core;

namespace LifeSim.Logger.Models
{
    public class Logger : Contracts.ILogger
    {
        public log4net.ILog GetLogger { get; private set; }

        public Logger()
        {
            this.GetLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().GetType());
        }
    }
}
