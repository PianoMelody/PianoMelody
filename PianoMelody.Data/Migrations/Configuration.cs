namespace PianoMelody.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

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

            if (!context.Resources.Any())
            {
                this.SeedResources(context);
            }
        }

        private void SeedResources(PianoMelodyContext context)
        {
            context.Resources.Add(new Resources { Name = "_AddAdministrator", Culture = "bg", Value = "Добави администратор" });
            context.Resources.Add(new Resources { Name = "_AddAdministrator", Culture = "en", Value = "Add administrator" });
            context.Resources.Add(new Resources { Name = "_AddAdministrator", Culture = "ru", Value = "Добави администратор" });
            context.Resources.Add(new Resources { Name = "_AddLabel", Culture = "bg", Value = "Добави надпис" });
            context.Resources.Add(new Resources { Name = "_AddLabel", Culture = "en", Value = "Add label" });
            context.Resources.Add(new Resources { Name = "_AddLabel", Culture = "ru", Value = "Добави надпис" });
            context.Resources.Add(new Resources { Name = "_Administration", Culture = "bg", Value = "Администрация" });
            context.Resources.Add(new Resources { Name = "_Administration", Culture = "en", Value = "Administration" });
            context.Resources.Add(new Resources { Name = "_Administration", Culture = "ru", Value = "Администрация" });
            context.Resources.Add(new Resources { Name = "_ChangePassword", Culture = "bg", Value = "Смени паролата" });
            context.Resources.Add(new Resources { Name = "_ChangePassword", Culture = "en", Value = "Change password" });
            context.Resources.Add(new Resources { Name = "_ChangePassword", Culture = "ru", Value = "Смени паролата" });
            context.Resources.Add(new Resources { Name = "_ConfirmPassword", Culture = "bg", Value = "Повторете паролата" });
            context.Resources.Add(new Resources { Name = "_ConfirmPassword", Culture = "en", Value = "Confirma password" });
            context.Resources.Add(new Resources { Name = "_ConfirmPassword", Culture = "ru", Value = "Повторете паролата" });
            context.Resources.Add(new Resources { Name = "_CurrentPassword", Culture = "bg", Value = "Текуща парола" });
            context.Resources.Add(new Resources { Name = "_CurrentPassword", Culture = "en", Value = "Current password" });
            context.Resources.Add(new Resources { Name = "_CurrentPassword", Culture = "ru", Value = "Текуща парола" });
            context.Resources.Add(new Resources { Name = "_Email", Culture = "bg", Value = "Електронна поща" });
            context.Resources.Add(new Resources { Name = "_Email", Culture = "en", Value = "Email" });
            context.Resources.Add(new Resources { Name = "_Email", Culture = "ru", Value = "Електронна поща" });
            context.Resources.Add(new Resources { Name = "_ErrInvalidEmail", Culture = "bg", Value = "Полето {0} е невалидно" });
            context.Resources.Add(new Resources { Name = "_ErrInvalidEmail", Culture = "en", Value = "The {0} field is not valid email address" });
            context.Resources.Add(new Resources { Name = "_ErrInvalidEmail", Culture = "ru", Value = "Полето {0} е невалидно" });
            context.Resources.Add(new Resources { Name = "_ErrLenghtValidation", Culture = "bg", Value = "Полето {0} трябва да бъде с дължина поне {2} символа" });
            context.Resources.Add(new Resources { Name = "_ErrLenghtValidation", Culture = "en", Value = "The {0} field must be at least {2} characters long" });
            context.Resources.Add(new Resources { Name = "_ErrLenghtValidation", Culture = "ru", Value = "Полето {0} трябва да бъде с дължина поне {2} символа" });
            context.Resources.Add(new Resources { Name = "_ErrRequired", Culture = "bg", Value = "Полето е задължително" });
            context.Resources.Add(new Resources { Name = "_ErrRequired", Culture = "en", Value = "The field is required" });
            context.Resources.Add(new Resources { Name = "_ErrRequired", Culture = "ru", Value = "Полето е задължително" });
            context.Resources.Add(new Resources { Name = "_Key", Culture = "bg", Value = "Ключ" });
            context.Resources.Add(new Resources { Name = "_Key", Culture = "en", Value = "Key" });
            context.Resources.Add(new Resources { Name = "_Key", Culture = "ru", Value = "Ключ" });
            context.Resources.Add(new Resources { Name = "_Label", Culture = "bg", Value = "надпис" });
            context.Resources.Add(new Resources { Name = "_Label", Culture = "en", Value = "label" });
            context.Resources.Add(new Resources { Name = "_Label", Culture = "ru", Value = "надпис" });
            context.Resources.Add(new Resources { Name = "_LabelCreated", Culture = "bg", Value = "Надписа е създаден" });
            context.Resources.Add(new Resources { Name = "_LabelCreated", Culture = "en", Value = "Label created" });
            context.Resources.Add(new Resources { Name = "_LabelCreated", Culture = "ru", Value = "Надписа е създаден" });
            context.Resources.Add(new Resources { Name = "_Login", Culture = "bg", Value = "Вход" });
            context.Resources.Add(new Resources { Name = "_Login", Culture = "en", Value = "Login" });
            context.Resources.Add(new Resources { Name = "_Login", Culture = "ru", Value = "Вход" });
            context.Resources.Add(new Resources { Name = "_LogOff", Culture = "bg", Value = "Изход" });
            context.Resources.Add(new Resources { Name = "_LogOff", Culture = "en", Value = "Log Off" });
            context.Resources.Add(new Resources { Name = "_LogOff", Culture = "ru", Value = "Изход" });
            context.Resources.Add(new Resources { Name = "_Name", Culture = "bg", Value = "Име" });
            context.Resources.Add(new Resources { Name = "_Name", Culture = "en", Value = "Name" });
            context.Resources.Add(new Resources { Name = "_Name", Culture = "ru", Value = "Име" });
            context.Resources.Add(new Resources { Name = "_NewPassword", Culture = "bg", Value = "Нова парола" });
            context.Resources.Add(new Resources { Name = "_NewPassword", Culture = "en", Value = "New password" });
            context.Resources.Add(new Resources { Name = "_NewPassword", Culture = "ru", Value = "Нова парола" });
            context.Resources.Add(new Resources { Name = "_Password", Culture = "bg", Value = "Парола" });
            context.Resources.Add(new Resources { Name = "_Password", Culture = "en", Value = "Password" });
            context.Resources.Add(new Resources { Name = "_Password", Culture = "ru", Value = "Парола" });
            context.Resources.Add(new Resources { Name = "_PasswordValidation", Culture = "bg", Value = "Паролите не съвпадат" });
            context.Resources.Add(new Resources { Name = "_PasswordValidation", Culture = "en", Value = "The passwords do not match" });
            context.Resources.Add(new Resources { Name = "_PasswordValidation", Culture = "ru", Value = "Паролите не съвпадат" });
            context.Resources.Add(new Resources { Name = "_Save", Culture = "bg", Value = "Запиши" });
            context.Resources.Add(new Resources { Name = "_Save", Culture = "en", Value = "Save" });
            context.Resources.Add(new Resources { Name = "_Save", Culture = "ru", Value = "Запиши" });
            context.Resources.Add(new Resources { Name = "Home", Culture = "bg", Value = "Начало" });
            context.Resources.Add(new Resources { Name = "Home", Culture = "en", Value = "Home" });
            context.Resources.Add(new Resources { Name = "Home", Culture = "ru", Value = "Начало" });
            context.Resources.Add(new Resources { Name = "Logo", Culture = "bg", Value = "Пиано" });
            context.Resources.Add(new Resources { Name = "Logo", Culture = "en", Value = "Piano" });
            context.Resources.Add(new Resources { Name = "Logo", Culture = "ru", Value = "Пиано" });

            context.SaveChanges();
        }
    }
}