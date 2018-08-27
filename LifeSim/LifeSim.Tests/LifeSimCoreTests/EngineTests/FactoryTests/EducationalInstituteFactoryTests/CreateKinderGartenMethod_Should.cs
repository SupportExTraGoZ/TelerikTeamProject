using LifeSim.Core.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.EducationalInstituteFactoryTests
{
    [TestClass]
    public class CreateKinderGartenMethod_Should
    {
        [TestMethod]
        public void ReturnCreatedObject_When_IsCalled()
        {
            var factory = new EducationalInstituteFactory();

            var kinderGarten = factory.CreateKinderGarten("Collegiate Garden", 2018);

            Assert.IsNotNull(kinderGarten);

        }
    }
}