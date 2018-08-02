using System;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;

namespace LifeSim.Core.Engine.Core.UserQuestion.Models
{
    public class Question : IQuestion
    {
        public string Text { get; set; }
        public string Answer { get; set; }
        public bool SameLine { get; set; } = true;
    }
}
