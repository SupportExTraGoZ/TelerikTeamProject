using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts
{
    public interface IConsoleRenderer
    {
        IConsoleWriter Writer { get; }
        IConsoleReader Reader { get; }
    }
}