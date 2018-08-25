using System.Collections.Generic;
using LifeSim.Player.Contracts;

namespace LifeSim.Core.Engine.Core.UserStatus.Contracts
{
    public interface IUserStatus
    {
        void WriteStatus(IPlayer player);
        void WriteActionLog(List<string> actions, int count);
    }
}