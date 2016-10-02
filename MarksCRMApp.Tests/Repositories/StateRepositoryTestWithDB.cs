using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;

namespace MarksCRMApp.Tests.Repositories
{
    [TestClass]
    public class StateRepositoryTestWithDB
    {

        TestContext databaseContext;
        StateRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {

            databaseContext = new TestContext();
            objRepo = new StateRepository(databaseContext);

        }

        //[TestMethod]
        //public void State_Repository_Get_ALL()
        //{
        //    //Act
        //    var result = objRepo.GetAll().ToList();

        //    //Assert

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(3, result.Count);
        //    Assert.AreEqual("Texas", result[0].Name);
        //    Assert.AreEqual("Alabama", result[1].Name);
        //    Assert.AreEqual("New York", result[2].Name);
        //}

        //[TestMethod]
        //public void State_Repository_Create()
        //{
        //    //Arrange
        //    State c = new State() { Name = "Washington" };

        //    //Act
        //    var result = objRepo.Add(c);
        //    databaseContext.SaveChanges();

        //    var lst = objRepo.GetAll().ToList();

        //    //Assert

        //    Assert.AreEqual(4, lst.Count);
        //    Assert.AreEqual("Washington", lst.Last().Name);
        //}
    }
}
