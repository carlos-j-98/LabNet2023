using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PracticaLINQ.Data.Queries;
using PracticaLINQ.Entities.DbEntities;
using System.Collections.Generic;

namespace PracticaLINQ.Logic.LogicBusiness.Tests
{
    [TestClass()]
    public class ProductLogicTests
    {
        [TestMethod()]
        public void GetNoStockProductsTest()
        {
            //Arrange
            var mockQuerie = new Mock<ProductQueries>();
            var logic = new ProductLogic(mockQuerie.Object);
            List<Products> productsExpected = new List<Products>()
            {
                new Products{ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", SupplierID = 2,QuantityPerUnit = "36 boxes",
                    CategoryID = 2, UnitPrice = 21.35m, UnitsInStock = 0 , UnitsOnOrder = 0 ,
                    ReorderLevel = 0, Discontinued = true },
                new Products{ProductID = 17, ProductName = "Alice Mutton", SupplierID = 7, QuantityPerUnit = "20 - 1 kg tins",
                    CategoryID = 6, UnitPrice = 39.00m, UnitsInStock = 0 , UnitsOnOrder = 0 ,
                    ReorderLevel = 0, Discontinued = true },
                new Products{ProductID = 29, ProductName = "Thüringer Rostbratwurst", SupplierID = 12,
                    QuantityPerUnit = "50 bags x 30 sausgs.",CategoryID = 6, UnitPrice = 123.79m, UnitsInStock = 0 ,
                    UnitsOnOrder = 0 ,ReorderLevel = 0, Discontinued = true },
                new Products{ProductID = 31, ProductName = "Gorgonzola Telino", SupplierID = 14,
                    QuantityPerUnit = "12 - 100 g pkgs.",CategoryID = 4, UnitPrice = 12.50m, UnitsInStock = 0 ,
                    UnitsOnOrder = 70 ,ReorderLevel = 20, Discontinued = false },
                new Products{ProductID = 53, ProductName = "Perth Pasties", SupplierID = 24,
                    QuantityPerUnit = "48 pieces",CategoryID = 6, UnitPrice = 32.80m, UnitsInStock = 0 ,
                    UnitsOnOrder = 0 ,ReorderLevel = 0, Discontinued = true }
            };
            //Act
            var result = logic.GetNoStockProducts();
            //Assert
            Assert.AreEqual(productsExpected.Count, result.Count);
            Assert.AreEqual(productsExpected[0].ProductID, result[0].ProductID);
            Assert.AreEqual(productsExpected[1].ProductID, result[1].ProductID);
            Assert.AreEqual(productsExpected[2].ProductID, result[2].ProductID);
        }

        [TestMethod()]
        public void GetProductNullTest()
        {
            //Arrange
            var mockQuerie = new Mock<ProductQueries>();
            var logic = new ProductLogic(mockQuerie.Object);
            Products productExpected = null;
            //Act
            var result = logic.GetProduct(789);
            //Assert
            Assert.AreEqual(productExpected, result);
        }

        [TestMethod()]
        public void GetOneProductTest()
        {
            //Arrange
            var mockQuerie = new Mock<ProductQueries>();
            var logic = new ProductLogic(mockQuerie.Object);
            Products productExpected = new Products()
            {
                ProductID = 1,
                ProductName = "Chai",
                SupplierID = 1,
                CategoryID = 1,
                QuantityPerUnit = "10 boxes x 20 bags",
                UnitPrice = 18.00m,
                UnitsInStock = 39,
                UnitsOnOrder = 0,
                Discontinued = false
            };
            //Act
            var result = logic.GetOneProduct();
            //Assert
            Assert.AreEqual(productExpected.CategoryID, result.CategoryID);
            Assert.AreEqual(productExpected.ProductName, result.ProductName);
            Assert.AreEqual(productExpected.CategoryID, result.CategoryID);
        }
    }
}