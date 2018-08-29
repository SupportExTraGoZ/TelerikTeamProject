namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts
{
    public interface IQuestion
    {
        string Answer { get; set; }
        string Text { get; set; }
        bool SameLine { get; set; }
    }
}