using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LabNetPractica2.Application.ExtensionMethods.Tests
{
    [TestClass()]
    public class ExceptionExtensionTests
    {
        [TestMethod()]
        public void MessageExtensionTest()
        {
            //Arrange
            Exception ex = new DivideByZeroException("Intento dividir por cero");
            string expectedResult = "Mensaje: Intento dividir por cero \n";
            //Act
            string result = ex.MessageExtension();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        public void TipeExtensionTest()
        {
            //Arrange
            Exception ex = new DivideByZeroException("Intento dividir por cero");
            string expectedResult = "Tipo: System.DivideByZeroException \n";
            //Act
            string result = ex.TipeExtension();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}