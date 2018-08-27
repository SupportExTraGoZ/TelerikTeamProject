using LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.EducationalInstituteTests.
    MockEducationInstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.EducationalInstituteTests
{
    [TestClass]
    public class StartYearGetter_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetMethodIsCalled()
        {
            var name = "Stanford University";
            var startYear = 2018;
            var mockEducationalInstitute = new MockEducationalInstitute(name, startYear);

            var result = mockEducationalInstitute.StartYear;

            Assert.AreEqual(startYear, result);
        }
    }
}