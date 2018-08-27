using LifeSim.Core.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.EducationalInstituteFactoryTests
{
    [TestClass]
    public class CreateUniversityMethod_Should
    {
        [TestMethod]
        public void ReturnCreatedObject_When_IsCalled()
        {
            var factory = new EducationalInstituteFactory();

            var university = factory.CreateUniversity("Harvard University", 2018);

            Assert.IsNotNull(university);

        }
    }
}
