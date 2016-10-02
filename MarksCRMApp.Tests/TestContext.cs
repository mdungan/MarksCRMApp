using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Tests
{
    public class TestContext : DbContext
    {
        public TestContext()
            : base("Name=TestContext")
        {

        }
        public TestContext(bool enableLazyLoading, bool enableProxyCreation)
            : base("Name=TestContext")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }
        public TestContext(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Note> Notes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<TestContext>(new AlwaysCreateInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(TestContext Context)
        {
            var listState = new List<State>() {
               new State() { Id = 1, Name = "Texas" },
               new State() { Id = 2, Name = "Alabama" },
               new State() { Id = 3, Name = "New York" }
              };
            Context.States.AddRange(listState);

            var listCustomer = new List<Customer>() {
             new Customer() { Id = 1, FirstName = "Bob", LastName = "Smith", CompanyName="ABC Company", Address = "123 Street", StateId = 1, EmailAddress = "Bob@abc.com", PhoneNumber = "123-456-7890" },
             new Customer() { Id = 2, FirstName = "Ann", LastName = "Smith", CompanyName="DEF Corporation", Address = "456 Street", StateId = 1, EmailAddress = "Ann@def.com", PhoneNumber = "123-456-7891" },
             new Customer() { Id = 3, FirstName = "John", LastName = "Doe", CompanyName="GHI Limited", Address = "789 Street", StateId = 1, EmailAddress = "John@ghi.com", PhoneNumber = "123-456-7892" }
            };
            Context.Customers.AddRange(listCustomer);


            var listNote = new List<Note>() {
             new Note() { Id = 1, Body = "This is the first note.", CustomerId = 1 },
             new Note() { Id = 2, Body = "This is the second note.", CustomerId = 1 },
             new Note() { Id = 3, Body = "This is the third note.", CustomerId = 2 }
            };
            Context.Notes.AddRange(listNote);
            Context.SaveChanges();

        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<TestContext>
        {
            protected override void Seed(TestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<TestContext>
        {
            protected override void Seed(TestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<TestContext>
        {
            protected override void Seed(TestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }


    }

}
