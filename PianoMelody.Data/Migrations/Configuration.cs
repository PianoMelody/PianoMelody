namespace PianoMelody.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using PianoMelody.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<PianoMelodyContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PianoMelodyContext context)
        {
            if (!context.Users.Any(u => u.UserName == "melodia.ltd@abv.bg"))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                var admin = new User
                    {
                        UserName = "melodia.ltd@abv.bg",
                        Email = "melodia.ltd@abv.bg"
                    };

                userManager.Create(admin, "123456");

                var adminRole = new IdentityRole { Name = "Admin" };
                context.Roles.Add(adminRole);

                var identityRole = new IdentityUserRole { RoleId = adminRole.Id, UserId = admin.Id };
                adminRole.Users.Add(identityRole);

                context.SaveChanges();
            }
        }
    }
}