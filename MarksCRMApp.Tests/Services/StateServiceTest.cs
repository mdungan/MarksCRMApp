using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using MarksCRMApp.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Tests.Services
{
    [TestClass]
    public class StateServiceTest
    {
        private Mock<IStateRepository> _mockRepository;
        private IStateService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<State> listState;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IStateRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new StateService(_mockUnitWork.Object, _mockRepository.Object);
            listState = new List<State>() {
             new State() { Id = 1, Name = "Texas" },
             new State() { Id = 2, Name = "Alabama" },
             new State() { Id = 3, Name = "New York" }
            };
        }

        [TestMethod]
        public void State_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listState);

            //Act
            List<State> results = _service.GetAll() as List<State>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        [TestMethod]
        public void Can_Add_State()
        {
            //Arrange
            int Id = 1;
            State emp = new State() { Name = "UK" };
            _mockRepository.Setup(m => m.Add(emp)).Returns((State e) =>
            {
                e.Id = Id;
                return e;
            });


            //Act
            _service.Create(emp);

            //Assert
            Assert.AreEqual(Id, emp.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }


    }
}
