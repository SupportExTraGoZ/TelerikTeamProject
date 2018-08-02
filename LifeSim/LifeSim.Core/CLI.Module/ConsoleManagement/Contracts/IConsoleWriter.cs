namespace LifeSim.Core.CLI.Module.ConsoleManagement.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLine(string line);

        void Write(string line);

        void PrintLogo();

        void SetCenterCursorPosition(string name);

    }
}