﻿using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts
{
    public interface IRenderer
    {
        IConsoleWriter Writer { get; }
        IConsoleReader Reader { get; }
    }
}
