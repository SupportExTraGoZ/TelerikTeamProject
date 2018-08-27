using LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.EducationalInstituteTests.
    MockEducationInstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.EducationalInstituteTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var name = "Stanford University";
            var startYear = 2018;

            var mockEducationalInstitute = new MockEducationalInstitute(name, startYear);

            Assert.IsInstanceOfType(mockEducationalInstitute, typeof(MockEducationalInstitute));
            Assert.IsNotNull(mockEducationalInstitute);
        }

        [TestMethod]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            var name = "Stanford University";
            var startYear = 2018;

            var mockEducaitonalInstitute = new MockEducationalInstitute(name, startYear);

            Assert.AreEqual(name, mockEducaitonalInstitute.BuildingName);
        }

        [TestMethod]
        public void SetProperStartYear_WhenTheObjectIsConstructed()
        {
            var name = "Stanford University";
            var startYear = 2018;

            var mockEducaitonalInstitute = new MockEducationalInstitute(name, startYear);

            Assert.AreEqual(startYear, mockEducaitonalInstitute.StartYear);
        }
    }
}