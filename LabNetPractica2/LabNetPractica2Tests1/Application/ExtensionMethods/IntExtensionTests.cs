using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabNetPractica2.Application.ExtensionMethods.Tests
{
    [TestClass()]
    public class IntExtensionTests
    {
        [TestMethod()]
        public void DivideTest()
        {
            //Arrange
            double numerator = 10;
            double denominator = 10;
            double expectedResult = 1;
            //Act
            double result = numerator.Divide(denominator);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        public void DivideRacionalTest()
        {
            //Arrange
            double numerator = 10;
            double denominator = 2.5;
            int expectedResult = 4;
            //Act
            double result = numerator.Divide(denominator);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        public void DivideZeroTest()
        {
            //Arrange
            double numerator = 10;
            double denominator = 0;
            double expectedResult = double.PositiveInfinity;
            //Act
            double result = numerator.Divide(denominator);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}