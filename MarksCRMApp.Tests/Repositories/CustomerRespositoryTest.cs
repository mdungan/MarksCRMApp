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
    public class CustomerRespositoryTest
    {
        DbConnection connection;
        TestContext databaseContext;
        CustomerRepository objRepo;

        [OneTimeSetUp]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new TestContext(connection);
            objRepo = new CustomerRepository(databaseContext);

        }

        [Test]
        public void CustomerRepository_GetAll()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual("Bob", result[0].FirstName);
            Assert.AreEqual("Smith", result[1].LastName);
            Assert.AreEqual("GHI Limited", result[2].CompanyName);
        }

        [Test]
        public void CustomerRepository_GetWithNonExistentId_ReturnsNull()
        {
            //Act
            var result = objRepo.GetById(145);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CustomerRepository_GetById_Return1()
        {
            //Arrange
            var Customer = new Customer() { FirstName = "Mark", LastName = "Jeffries", CompanyName = "Google", Address = "789 Street", StateId = 1, EmailAddress = "Mark@Google.com", PhoneNumber = "123-456-7892" };
            objRepo.Add(Customer);
            databaseContext.SaveChanges();

            //Act
            var result = objRepo.GetById(Customer.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Mark@Google.com", result.EmailAddress);
        }

        [Test]
        public void Customer_Repository_Create()
        {
            //Arrange
            Customer c = new Customer() { FirstName = "Graham", LastName = "Elliot", CompanyName = "Safeway", Address = "456 Lane", StateId = 1, EmailAddress = "Graham@Safeway.com", PhoneNumber = "123-456-7893" };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("Elliot", lst.Last().LastName);
        }

        public void CustomerRepository_Delete()
        {
            //Arrange
            Customer c = new Customer() { FirstName = "Bill", LastName = "Nye", CompanyName = "XYZ Limited", Address = "789 Street", StateId = 1, EmailAddress = "John@ghi.com", PhoneNumber = "123-456-7892" };
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();
            var cnt = objRepo.GetAll().Count();

            //Act
            objRepo.Delete(c);
            databaseContext.SaveChanges();
            var lst = objRepo.GetAll().ToList();

            //Assert
            Assert.AreEqual(cnt - 1, lst.Count);

        }
    }
}
