using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSim.Player.Models;
using LifeSim.Player.Randomizer.Models;

namespace LifeSim.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void ApplyForJob_SoftwareEngineer()
        {
            // Arrange
            var tempPlayer = new Player.Models.Player("Danail", "Grozdanov", Player.Enums.GenderType.Male, Player.Enums.Birthplaces.Miami, new FamilyGenerator());
            tempPlayer.IsTakingLessons = true;
            tempPlayer.IsSuccessfulAtUniversity = true;

            // Act


            // Assert
        }
    }
}