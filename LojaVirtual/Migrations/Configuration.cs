namespace LojaVirtual.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaVirtual.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LojaVirtual.Models.ApplicationDbContext context)
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

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
            }

            var PasswordHash = new PasswordHasher();

            if (!context.Users.Any(u => u.UserName == "admin@s2b.br"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@s2b.br",
                    Name = "Admin",
                    Telephone = "51 92375412",
                    Email = "admin@s2b.br",
                    PasswordHash = PasswordHash.HashPassword("s2b")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "hugo@s2b.br"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "hugo@s2b.br",
                    Name = "Hugo",
                    Telephone = "51 92432432",
                    Email = "hugo@s2b.br",
                    PasswordHash = PasswordHash.HashPassword("s2b")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "User");
            }

            if (!context.Users.Any(u => u.UserName == "ze@s2b.br"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "ze@s2b.br",
                    Name = "Ze",
                    Telephone = "51 87655412",
                    Email = "ze@s2b.br",
                    PasswordHash = PasswordHash.HashPassword("s2b")
                };


                manager.Create(user);
                manager.AddToRole(user.Id, "User");
            }

            if (!context.Users.Any(u => u.UserName == "luis@s2b.br"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "luis@s2b.br",
                    Name = "Luis",
                    Telephone = "51 32334412",
                    Email = "luis@s2b.br",
                    PasswordHash = PasswordHash.HashPassword("s2b")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "User");
            }

        }
    }
}
