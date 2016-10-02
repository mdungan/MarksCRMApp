using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using MarksCRMApp.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Tests.Repositories
{
    [TestFixture]
    public class NoteRespositoryTest
    {
        DbConnection connection;
        TestContext databaseContext;
        NoteRepository objRepo;

        [OneTimeSetUp]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new TestContext(connection);
            objRepo = new NoteRepository(databaseContext);

        }

        [Test]
        public void NoteRepository_GetAll()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            //Assert.AreEqual(3, result.Count);
            Assert.AreEqual("This is the first note.", result[0].Body);
            Assert.AreEqual("This is the second note.", result[1].Body);
            Assert.AreEqual("This is the third note.", result[2].Body);
        }

        [Test]
        public void NoteRepository_GetWithNonExistentId_ReturnsNull()
        {
            //Act
            var result = objRepo.GetById(145);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void NoteRepository_GetById_Return1()
        {
            //Arrange
            var note = new Note();
            note.Body = "This is another note.";
            note.CustomerId = 1;
            objRepo.Add(note);
            databaseContext.SaveChanges();

            //Act
            var result = objRepo.GetById(note.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("This is another note.", result.Body);
        }

        [Test]
        public void NoteRepository_GetByCustomerId_Return2()
        {
            //Act
            var result = objRepo.GetByCustomerId(1).ToList();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].CustomerId);
            Assert.AreEqual(1, result[1].CustomerId);
        }


        [Test]
        public void Note_Repository_Create()
        {
            //Arrange
            Note c = new Note() { Body = "This is the fourth note.", CustomerId = 3 };
            var cnt = objRepo.GetAll().Count();

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert
            Assert.AreEqual(cnt + 1, lst.Count);
            Assert.AreEqual("This is the fourth note.", lst.Last().Body);
        }

        [Test]
        public void NoteRepository_Delete()
        {
            //Arrange
            Note c = new Note() { Body = "This is the fourth note.", CustomerId = 3 };
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();
            var cnt = objRepo.GetAll().Count();

            //Act
            objRepo.Delete(c);
            databaseContext.SaveChanges();
            var lst = objRepo.GetAll().ToList();

            //Assert
            Assert.AreEqual(cnt -1, lst.Count);
        }
    }
}