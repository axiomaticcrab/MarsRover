using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Test.CommonTest
{
    [TestClass]
    public class LocationTests
    {
        #region Initialize

        [TestMethod]
        [ExpectedException(typeof (RequiredParameterMissingException))]
        public void Should_ThrowRequiredParameterMissingException_When_MandatoryFieldsIsMissing()
        {
            var position = default(Position);
            var direction = default(Direction);

            new Location().With(position, direction);
        }

        #endregion

    }
}
