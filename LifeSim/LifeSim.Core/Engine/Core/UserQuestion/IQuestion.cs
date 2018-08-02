namespace LifeSim.Core.Engine.Core.UserQuestion
{
    public interface IQuestion
    {
        string Answer { get; set; }
        string Text { get; set; }

        bool IsValid(string answer);
    }
}