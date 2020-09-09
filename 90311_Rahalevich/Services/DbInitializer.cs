using _90311_Rahalevich.DAL.Data;
using _90311_Rahalevich.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _90311_Rahalevich.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            //проверка наличия групп объектов
            if (!context.InsulinGroups.Any())
            {
                context.InsulinGroups.AddRange(
                new List<InsulinGroup>
                {
                new InsulinGroup {GroupName="Fast"},
                new InsulinGroup {GroupName="Very fast"},
                new InsulinGroup {GroupName="Long"},
                new InsulinGroup {GroupName="Very long"},
                new InsulinGroup {GroupName="Slow"},
                new InsulinGroup {GroupName="Normal"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Insulins.Any())
            {
                context.Insulins.AddRange(
                new List<Insulin>
                {
                new Insulin {InsulinName = "Novorapid", Publisher = "NovoNordisk", Rating = 8, InsulinGroupId = 1, Image = "novorapid.jpg" },
                new Insulin {InsulinName = "Fiasp", Publisher = "NovoNordisk", Rating = 7, InsulinGroupId = 2, Image = "fiasp.jpg" },
                new Insulin {InsulinName = "Levemir", Publisher = "NovoNordisk", Rating = 6, InsulinGroupId = 3, Image = "levemir.jpg" },
                new Insulin {InsulinName = "Tresiba", Publisher = "NovoNordisk", Rating = 9, InsulinGroupId = 4, Image = "tresiba.jpg" },
                new Insulin {InsulinName = "Apidra", Publisher = "Sanofi", Rating = 10, InsulinGroupId = 2, Image = "apidra.jpg" },
                new Insulin {InsulinName = "Lantus", Publisher = "Sanofi", Rating = 6, InsulinGroupId = 5, Image = "lantus.jpg" },
                new Insulin {InsulinName = "Tudgeo", Publisher = "Sanofi", Rating = 9, InsulinGroupId = 6, Image = "tudgeo.jpg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
