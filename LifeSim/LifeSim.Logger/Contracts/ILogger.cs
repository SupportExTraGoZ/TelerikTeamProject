using System;
namespace LifeSim.Logger.Contracts
{
    public interface ILogger
    {
        log4net.ILog GetLogger { get; }
    }
}
