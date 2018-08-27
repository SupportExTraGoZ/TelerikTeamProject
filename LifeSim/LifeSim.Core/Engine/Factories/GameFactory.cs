using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Factories.Contracts;

namespace LifeSim.Core.Engine.Factories
{
    public class GameFactory : IGameFactory
    {
        public IPlayerFactory PlayerFactory { get; }
        public IJobFactory JobFactory { get; }
        public IEducationalInstituteFactory EducationalInstituteFactory { get; }

        public GameFactory(IPlayerFactory playerFactory, IJobFactory jobFactory, IEducationalInstituteFactory educationalInstituteFactory)
        {
            PlayerFactory = playerFactory;
            JobFactory = jobFactory;
            EducationalInstituteFactory = educationalInstituteFactory;
        }
    }
}
