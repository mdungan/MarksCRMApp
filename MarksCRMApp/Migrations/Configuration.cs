using MarksCRMApp.Model;
namespace MarksCRMApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MarksCRMApp.Model.MarksCRMAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MarksCRMApp.Model.MarksCRMAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.States.AddOrUpdate(
                p => p.Name,
                new State { Name = "Alabama"},
                new State { Name = "Alaska" },
                new State { Name = "Arizona" },
                new State { Name = "Arkansas" },
                new State { Name = "California" },
                new State { Name = "Colorado" },
                new State { Name = "Connecticut" },
                new State { Name = "Delaware" },
                new State { Name = "Florida" },
                new State { Name = "Georgia" },
                new State { Name = "Hawaii" },
                new State { Name = "Idaho" },
                new State { Name = "Illinois" },
                new State { Name = "Indiana" },
                new State { Name = "Iowa" },
                new State { Name = "Kansas" },
                new State { Name = "Kentucky" },
                new State { Name = "Louisiana" },
                new State { Name = "Maine" },
                new State { Name = "Maryland" },
                new State { Name = "Massachusetts" },
                new State { Name = "Michigan" },
                new State { Name = "Minnesota" },
                new State { Name = "Mississippi" },
                new State { Name = "Missouri" },
                new State { Name = "Montana" },
                new State { Name = "Nebraska" },
                new State { Name = "Nevada" },
                new State { Name = "New Hampshire" },
                new State { Name = "New Jersey" },
                new State { Name = "New Mexico" },
                new State { Name = "New York" },
                new State { Name = "North Carolina" },
                new State { Name = "North Dakota" },
                new State { Name = "Ohio" },
                new State { Name = "Oklahoma" },
                new State { Name = "Oregon" },
                new State { Name = "Pennsylvania" },
                new State { Name = "Rhode Island" },
                new State { Name = "South Carolina" },
                new State { Name = "South Dakota" },
                new State { Name = "Tennessee" },
                new State { Name = "Texas" },
                new State { Name = "Utah" },
                new State { Name = "Vermont" },
                new State { Name = "Virginia" },
                new State { Name = "Washington" },
                new State { Name = "West Virginia" },
                new State { Name = "Wisconsin" },
                new State { Name = "Wyoming" }
            );
        }
    }
}
