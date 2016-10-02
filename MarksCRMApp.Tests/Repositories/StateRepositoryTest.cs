using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Tests.Repositories
{
    [TestClass]
    public class StateRepositoryTest
    {
        DbConnection connection;
        TestContext databaseContext;
        StateRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new TestContext(connection);
            objRepo = new StateRepository(databaseContext);

        }

        [TestMethod]
        public void StateRepository_GetAll()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("Texas", result[0].Name);
            Assert.AreEqual("Alabama", result[1].Name);
            Assert.AreEqual("New York", result[2].Name);
        }

        [TestMethod]
        public void StateRepository_GetWithNonExistentId_ReturnsNull()
        {
            //Act
            var result = objRepo.GetById(145);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void StateRepository_GetById_Return1()
        {
            //Arrange
            var state = new State () { Name = "California" };
            objRepo.Add(state);
            databaseContext.SaveChanges();

            //Act
            var result = objRepo.GetById(state.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("California", result.Name);
        }

        [TestMethod]
        public void StateRepository_Create()
        {
            //Arrange
            State c = new State() { Name = "Washington" };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("Washington", lst.Last().Name);
        }
    }
}
