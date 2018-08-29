using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Models
{
    public class Question : IQuestion
    {
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool SameLine { get; set; } = true;
    }
}