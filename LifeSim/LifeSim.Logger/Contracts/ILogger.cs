using log4net;

namespace LifeSim.Logger.Contracts
{
    public interface ILogger
    {
        ILog GetLogger { get; }
    }
}