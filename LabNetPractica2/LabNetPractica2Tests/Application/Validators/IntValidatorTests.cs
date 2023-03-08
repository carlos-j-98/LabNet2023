using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabNetPractica2.Application.Validators.Tests
{
    [TestClass()]
    public class IntValidatorTests
    {
        [TestMethod()]
        public void IsZeroTest()
        {
            //Arrange
            double value = 0;
            bool expectedResult = true;
            //Act
            bool result = IntValidator.IsZero(value);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        public void NotIsZeroTest()
        {
            //Arrange
            double value = 1;
            bool expectedResult = false;
            //Act
            bool result = IntValidator.IsZero(value);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}