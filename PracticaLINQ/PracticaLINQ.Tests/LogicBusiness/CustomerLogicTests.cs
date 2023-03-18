using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PracticaLINQ.Data.Queries;
using PracticaLINQ.Entities.DbEntities;
using PracticaLINQ.Entities.DTO;
using System.Collections.Generic;

namespace PracticaLINQ.Logic.LogicBusiness.Tests
{
    [TestClass()]
    public class CustomerLogicTests
    {
        [TestMethod()]
        public void GetCustomersUpperLowerCaseTest()
        {
            //Arrange
            var mockQuerie = new Mock<CustomerQueries>();
            var logic = new CustomerLogic(mockQuerie.Object);
            var resultExpected = new List<CustomersUpperLowerDTO>
            {
                new CustomersUpperLowerDTO(){ lowerName = "maria anders", upperName = "MARIA ANDERS"},
                new CustomersUpperLowerDTO(){ lowerName = "ana trujillo", upperName = "ANA TRUJILLO"},
                new CustomersUpperLowerDTO(){ lowerName = "antonio moreno", upperName = "ANTONIO MORENO"}
            };
            //Act
            var result = logic.GetCustomersUpperLowerCase();
            //Assert
            Assert.AreEqual(resultExpected[0].lowerName, result[0].lowerName);
            Assert.AreEqual(resultExpected[0].upperName, result[0].upperName);
            Assert.AreEqual(resultExpected[1].lowerName, result[1].lowerName);
            Assert.AreEqual(resultExpected[1].upperName, result[1].upperName);
            Assert.AreEqual(resultExpected[2].lowerName, result[2].lowerName);
            Assert.AreEqual(resultExpected[2].upperName, result[2].upperName);
        }

        [TestMethod()]
        public void GetOneCustomerTest()
        {
            //Arrange
            var mockQuerie = new Mock<CustomerQueries>();
            var logic = new CustomerLogic(mockQuerie.Object);
            var resultExpecte = new Customers()
            {
                CustomerID = "ALFKI",
                CompanyName = "Alfreds Futterkiste",
                ContactName = "Maria Anders",
                ContactTitle = "Sales Representative",
                Address = "Obere Str. 57",
                City = "Berlin",
                Region = null,
                PostalCode = "12209",
                Country = "Germany",
                Phone = "030-0074321",
                Fax = "030-0076545"
            };
            //Act
            var result = logic.GetOneCustomer();
            //Assert
            Assert.AreEqual(resultExpecte.CustomerID, result.CustomerID);
            Assert.AreEqual(resultExpecte.CompanyName, result.CompanyName);
            Assert.AreEqual(resultExpecte.ContactName, result.ContactName);
        }

        [TestMethod()]
        public void GetCustCantOrderTest()
        {
            //Arrange
            var mockQuerie = new Mock<CustomerQueries>();
            var logic = new CustomerLogic(mockQuerie.Object);
            var resultExpected = new List<CustCantOrderDTO>()
            {
                new CustCantOrderDTO()
                {custName = "Alejandra Camino", asociedOrders = "10281,10282,10306,10917,11013",cantOrders =5},
                new CustCantOrderDTO()
                {custName = "Alexander Feuer", asociedOrders = "10277,10575,10699,10779,10945",cantOrders =5},
                new CustCantOrderDTO()
                {custName = "Ana Trujillo", asociedOrders = "10308,10625,10759,10926",cantOrders =4}
            };
            //Act
            var result = logic.GetCustCantOrder();
            //Assert
            Assert.AreEqual(resultExpected[0].custName, result[0].custName);
            Assert.AreEqual(resultExpected[0].asociedOrders, result[0].asociedOrders);
            Assert.AreEqual(resultExpected[0].cantOrders, result[0].cantOrders);
            Assert.AreEqual(resultExpected[1].custName, result[1].custName);
            Assert.AreEqual(resultExpected[1].asociedOrders, result[1].asociedOrders);
            Assert.AreEqual(resultExpected[1].cantOrders, result[1].cantOrders);
            Assert.AreEqual(resultExpected[2].custName, result[2].custName);
            Assert.AreEqual(resultExpected[2].asociedOrders, result[2].asociedOrders);
            Assert.AreEqual(resultExpected[2].cantOrders, result[2].cantOrders);
        }
    }
}