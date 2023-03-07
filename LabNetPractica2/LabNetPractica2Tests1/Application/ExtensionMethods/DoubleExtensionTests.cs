﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabNetPractica2.Application.ExtensionMethods.Tests
{
    [TestClass()]
    public class DoubleExtensionTests
    {
        [TestMethod()]
        public void WriteResultTest()
        {
            //Arrange
            double value = 10;
            string expectedResult = "El resultado de la division es 10 \n";
            //Act
            string result = value.WriteResult();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}