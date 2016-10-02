using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MarksCRMApp.Service;
using MarksCRMApp.Controllers;
using MarksCRMApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace MarksCRMApp.Tests.Controllers
{
    [TestClass]
    public class StateControllerTest
    {
        private Mock<IStateService> _stateServiceMock;
        StateController objController;
        List<State> listState;

        [TestInitialize]
        public void Initialize()
        {

            _stateServiceMock = new Mock<IStateService>();
            objController = new StateController(_stateServiceMock.Object);
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
            _stateServiceMock.Setup(x => x.GetAll()).Returns(listState);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<State>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("Texas", result[0].Name);
            Assert.AreEqual("Alabama", result[1].Name);
            Assert.AreEqual("New York", result[2].Name);

        }

        [TestMethod]
        public void Valid_State_Create()
        {
            //Arrange
            State c = new State() { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert 
            _stateServiceMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void Invalid_State_Create()
        {
            // Arrange
            State c = new State() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _stateServiceMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }

    }
}
