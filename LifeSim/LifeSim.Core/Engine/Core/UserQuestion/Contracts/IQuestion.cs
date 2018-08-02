namespace LifeSim.Core.Engine.Core.UserQuestion.Contracts
{
    public interface IQuestion
    {
        string Answer { get; set; }
        string Text { get; set; }
        bool SameLine { get; set; }
    }
}