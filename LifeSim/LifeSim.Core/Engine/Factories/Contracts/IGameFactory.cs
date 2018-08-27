using LifeSim.Core.Engine.Factories.Contracts;

namespace LifeSim.Core.Engine.Factories.Contracts
{
    public interface IGameFactory
    {
        IEducationalInstituteFactory EducationalInstituteFactory { get; }
        IJobFactory JobFactory { get; }
        IPlayerFactory PlayerFactory { get; }
    }
}