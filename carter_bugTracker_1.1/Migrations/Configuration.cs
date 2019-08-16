namespace carter_bugTracker_1._1.Migrations
{
    using carter_bugTracker_1._1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<carter_bugTracker_1._1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(carter_bugTracker_1._1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //#regionroleManager

            context.TicketPriorities.AddOrUpdate(
                t => t.Name,
                new TicketPriority { Name = "Immediate", Description = "Highest priority level requiring immediate action" },
                new TicketPriority { Name = "High", Description = "High priority level requiring action" },
                new TicketPriority { Name = "Medium", Description = "priority level requiring action" },
                new TicketPriority { Name = "Low", Description = "priority level requiring action" },
                new TicketPriority { Name = "None", Description = "priority level requiring action" }
                );

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            //#endregion
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "dc.carter.dev@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "dc.carter.dev@gmail.com",
                    Email = "dc.carter.dev@gmail.com",
                    FirstName = "dimitri",
                    LastName = "carter",
                    DisplayName = "dcart",
                }, "Abc&123");
            }

            if (!context.Users.Any(u => u.Email == "joeschmoe@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "joeschmoe@mailinator.com",
                    Email = "joeschmoe@mailinator.com",
                    FirstName = "joe",
                    LastName = "schmoe",
                    DisplayName = "jschm",
                }, "Abc&123");
            }
            var userId = userManager.FindByEmail("dc.carter.dev@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("joeschmoe@mailinator.com").Id;
            userManager.AddToRole(userId, "Moderator");
        }
    }
}
