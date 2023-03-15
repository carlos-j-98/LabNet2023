using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Practica4.EF.Data.Queries;
using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Data.Repositorys;
using Practica4.EF.Entities.EntitiesDatabase;
using System.Collections.Generic;

namespace Practica4.EF.Services.Tests
{
    [TestClass()]
    public class TerritorieServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrage
            var mockQuerie = new Mock<ITerritoriesQueries>();
            var mockRepo = new Mock<IRepository>();
            var terriService = new TerritorieService(mockQuerie.Object, mockRepo.Object);
            //Act
            terriService.Add(new Territories
            {
                TerritoryID = "0000",
                TerritoryDescription = "Test",
                RegionID = 1
            });
            //Assert
            mockRepo.Verify(m => m.Add(It.IsAny<Territories>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
            var mockQuerie = new Mock<ITerritoriesQueries>();
            var mockRepo = new Mock<IRepository>();
            var terriService = new TerritorieService(mockQuerie.Object, mockRepo.Object);
            int select = 4;
            //Act
            terriService.Delete(select);
            //Assert
            mockRepo.Verify(m => m.Delete<Territories>(It.IsAny<int>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //Arrange
            var mockQuerie = new Mock<ITerritoriesQueries>();
            var mockRepo = new Mock<IRepository>();
            var terriService = new TerritorieService(mockQuerie.Object, mockRepo.Object);
            //Act
            terriService.Update(new Territories
            {
                TerritoryID = "0000",
                TerritoryDescription = "Test",
                RegionID = 1
            });
            //Assert
            mockRepo.Verify(m => m.Update(It.IsAny<Territories>()), Times.Once());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Arrange
            var mockQuerie = new Mock<TerritorieQueries>();
            var mockRepo = new Mock<Repository>();
            var terriService = new TerritorieService(mockQuerie.Object, mockRepo.Object);
            var dataExpected = new List<Territories>
            {
                new Territories { TerritoryDescription = "Westboro                                          " },
                new Territories { TerritoryDescription = "Bedford                                           " },
                new Territories { TerritoryDescription = "Georgetow                                         " },
            };
            //Act
            var result = terriService.GetAll();
            //Asster
            Assert.AreEqual(dataExpected[0].TerritoryDescription, result[0].TerritoryDescription);
            Assert.AreEqual(dataExpected[1].TerritoryDescription, result[1].TerritoryDescription);
            Assert.AreEqual(dataExpected[2].TerritoryDescription, result[2].TerritoryDescription);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //Arrange
            var mockQuerie = new Mock<TerritorieQueries>();
            var mockRepo = new Mock<Repository>();
            var terriService = new TerritorieService(mockQuerie.Object, mockRepo.Object);
            string select = "01581";
            var dataExpected = new Territories
            {
                TerritoryDescription = "Westboro                                          ",
                TerritoryID = "01581",
                RegionID = 1
            };
            //Act
            var result = terriService.GetById(select);
            //Assert
            Assert.AreEqual(dataExpected.TerritoryDescription, result.TerritoryDescription);
            Assert.AreEqual(dataExpected.TerritoryID, result.TerritoryID);
            Assert.AreEqual(dataExpected.RegionID, result.RegionID);
        }
    }
}