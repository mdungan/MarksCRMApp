using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using MarksCRMApp.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Tests.Services
{
    [TestFixture]
    public class NoteServiceTest
    {
        private Mock<INoteRepository> _mockRepository;
        private INoteService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Note> listNote;

        [OneTimeSetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<INoteRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new NoteService(_mockUnitWork.Object, _mockRepository.Object);
            listNote = new List<Note>() {
             new Note() { Id = 1, Body = "This is the first note." },
             new Note() { Id = 2, Body = "This is the second note." },
             new Note() { Id = 3, Body = "This is the third note." }
            };



        }


        [Test]
        public void NoteService_GetAll_Returns3()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listNote);

            //Act
            List<Note> results = _service.GetAll() as List<Note>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [Test]
        public void NoteService_Add_Note()
        {
            //Arrange
            int Id = 1;
            Note note = new Note() { Body = "This is a note from create note." };
            _mockRepository.Setup(m => m.Add(note)).Returns((Note e) =>
            {
                e.Id = Id;
                return e;
            });


            //Act
            _service.Create(note);

            //Assert
            Assert.AreEqual(Id, note.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }

    }
}
