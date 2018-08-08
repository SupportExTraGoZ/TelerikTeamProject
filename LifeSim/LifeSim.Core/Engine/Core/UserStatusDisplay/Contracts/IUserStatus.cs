using LifeSim.Player.Contracts;
using System.Collections.Generic;

namespace LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts
{
    public interface IUserStatus
    {
        void WriteStatus(IPlayer player);
        void WriteActionLog(List<string> actions, int count);
    }
}