using LifeSim.Core.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.EducationalInstituteFactoryTests
{
    [TestClass]
    public class CreatePrimarySchoolMethod_Should
    {
        [TestMethod]
        public void ReturnCreatedObject_When_IsCalled()
        {
            var factory = new EducationalInstituteFactory();

            var primarySchool = factory.CreatePrimarySchool("Neshkoro Elementary", 2018);

            Assert.IsNotNull(primarySchool);
        }
    }
}
