using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Module.Common.Exception;
using PlanetRover.Module.PlanetModule.Domain;

namespace PlanetRover.Test.PlanetModuleTest
{
    [TestClass]
    public class PlanetTests
    {
        #region Initialize

        [TestMethod]
        [ExpectedException(typeof(InvalidParameterException))]
        public void Should_ThrowInvalidParameterException_When_WidthEqualOrLessThanZero()
        {
            var width = 0;
            var height = 8;
            var name = "Mars";

            new Planet().With(width, height, name);
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredParameterMissingException))]
        public void Should_ThrowRequiredParameterMissingException_When_MandatoryFieldsIsMissing()
        {
            var width = 15;
            var height = 8;
            var name = String.Empty;

            new Planet().With(width, height, name);
        }

        #endregion

        [TestMethod]
        public void Should_GenerateTiles_When_MandatoryFieldsIsValid()
        {
            var width = 5;
            var height = 5;
            var name = "Mars";

            var planet = new Planet().With(width, height, name);

            Assert.AreEqual((width+1) * (height+1), planet.Tiles.Count);
            Assert.AreEqual(0, planet.Tiles.Min(t => t.Position.X));
            Assert.AreEqual(width, planet.Tiles.Max(t => t.Position.X));
        }
    }
}
