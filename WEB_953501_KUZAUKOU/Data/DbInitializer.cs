using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await roleManager.CreateAsync(roleAdmin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            } 

            if (!context.GuitarGroups.Any())
            {
                context.GuitarGroups.AddRange(
                    new List<GuitarGroup>
                    {
                        new GuitarGroup {GroupName = "Acoustic"},
                        new GuitarGroup {GroupName = "Classic"},
                        new GuitarGroup {GroupName = "Ukulele"},
                        new GuitarGroup {GroupName = "Electro"},
                        new GuitarGroup {GroupName = "Electro-acoustic"},
                        new GuitarGroup {GroupName = "Bass"}
                    });
                await context.SaveChangesAsync();
            }
            
            if (!context.Guitars.Any())
            {
                context.Guitars.AddRange(
                new List<Guitar>
                {
                    new Guitar
                    {
                        GuitarName = "Fender Alkaline Trio Malibu",
                        Description = "Legendary rock band signed guitar",
                        Strings = 6, GuitarGroupId = 1, Image = "trio.jpg"
                    },
                    new Guitar
                    {
                        GuitarName = "Cort Earth 200",
                        Description = "Cheap and pretty comfortable",
                        Strings = 6, GuitarGroupId = 1, Image = "cort.jpg"
                    },
                    new Guitar
                    {
                        GuitarName = "Ibanez RGD7421-BKF",
                        Description = "Amazing heavy and low sound",
                        Strings = 7, GuitarGroupId = 4, Image = "ibanez.jpg"
                    },
                    new Guitar
                    {
                        GuitarName = "Fender American Telecaster",
                        Description = "Vintage, made of maple",
                        Strings = 6, GuitarGroupId = 4, Image = "fender.jpg"
                    },
                    new Guitar
                    {
                        GuitarName = "MusicMan Sterling",
                        Description = "Lightweight head, stable tune",
                        Strings = 4, GuitarGroupId = 6, Image = "bass.jpg"
                    }
                });
                await context.SaveChangesAsync();
            }
            
        }
    }
}
