using LabNetPractica2.Application.CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LabNetPractica2.Application.Logic.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LaunchExceptionTest()
        {
            Logic.LaunchException();
        }
        [TestMethod()]
        [ExpectedException(typeof(CustomException))]
        public void LaunchExceptionCustomTest()
        {
            Logic.LaunchCustomException();
        }

    }
}