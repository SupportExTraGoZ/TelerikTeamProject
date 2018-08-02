using System;

namespace LifeSim.Core.Engine.Core.UserQuestion
{
    public class Question : IQuestion
    {
        public string Text { get; set; }
        public string Answer { get; set; }

        public bool IsValid(string answer)
        {
            return String.Compare(answer, Answer, true) == 0;
        }
    }
}
