using LifeSim.Core.CLI.Module.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Core.IO.Contracts;

namespace LifeSim.Core.Contracts.IO
{
    /// <summary>
    /// Connects IO work for the app. In this case connects app with CLI
    /// To use it with other clients add "CLIENT".Module structure and implement 
    /// connection with this client here
    /// </summary>
    public interface IInputOutput : IOCLIProvider, IReadable
    {

    }
}
