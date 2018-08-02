using LifeSim.Player.Contracts;

namespace LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts
{
    public interface IUserStatus
    {
        void WriteStatus(IPlayer player);
    }
}