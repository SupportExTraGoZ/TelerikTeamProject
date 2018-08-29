using LifeSim.Core.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.EducationalInstituteFactoryTests
{
    [TestClass]
    public class CreateHighSchoolMethod_Should
    {
        [TestMethod]
        public void ReturnCreatedObject_When_IsCalled()
        {
            var factory = new EducationalInstituteFactory();

            var highSchool = factory.CreateHighSchool("Scottsdale", 2018);
            
            Assert.IsNotNull(highSchool);
        }

        
    }
}
