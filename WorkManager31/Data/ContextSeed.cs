using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManager31.Models;

namespace WorkManager31.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "tryb77@wp.pl",
                FirstName = "superadmin",
                LastName = "superadmin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 10
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password123.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }

            }
        }

        /*public static Task SeedClientGroupsAsync(ApplicationDbContext dbContext)
        {
            List<ClientGroup> clientGroups = new List<ClientGroup>
            {
                new ClientGroup{Name = "POZ"},
                new ClientGroup{Name = "SOZ"},
                new ClientGroup{Name = "Rehabilitacja"},
                new ClientGroup{Name = "Stomatolog"},
                new ClientGroup{Name = "Rozliczenia"},
                new ClientGroup{Name = "SOMED"},
                new ClientGroup{Name = "PPS"},
                new ClientGroup{Name = "Serum"}
            };

            foreach (ClientGroup clientGroup in clientGroups)
            {
                if (dbContext.ClientGroup.FirstOrDefault<ClientGroup>(i=> i.Name == clientGroup.Name)== null)
                {
                    dbContext.ClientGroup.Add(clientGroup);
                }
            }
            dbContext.SaveChanges();
            
            return Task.FromResult(0);
        }
        */
        public static Task SeedClientsAsync(ApplicationDbContext dbContext)
        {
            
            

            List<Client> clients = new List<Client>
            {
                new Client { Name = "INMED"},
                new Client { Name = "VITAMED" },
                new Client { Name = "KACZMAREKMED"},
                new Client { Name = "HELPMED Brudzew"},
                new Client { Name = "SANMED Kłodawa" },
                new Client { Name = "Powidz" },
                new Client { Name = "Władysławów" },
                new Client { Name = "Wilczyn" },
                new Client { Name = "MEDICON Łężyn" },
                new Client { Name = "CYRULIK Dobra" },
                new Client { Name = "Tuliszków" },
                new Client { Name = "Kowale Pańskie" },
                new Client { Name = "Zagórów" },
                new Client { Name = "MEDINET" },
                new Client { Name = "FENIKS Bogacki" },
                new Client { Name = "Chmielewska Rehabilitacja" },
                new Client { Name = "MEDINET" },
                new Client { Name = "MEDYK Turek" },
                new Client { Name = "MEDICUS Turek" },
                new Client { Name = "Kramsk" },
                new Client { Name = "MEDALKO" },
                new Client { Name = "MAR MAXMED1" },
                new Client { Name = "MEDINET" },
                new Client { Name = "Kazimierz Biskupi" },
                new Client { Name = "ÓSEMKA" },
                new Client { Name = "KOLMED" },
                new Client { Name = "MEDINET" },
                new Client { Name = "ORTOMED Koło" },
                new Client { Name = "ONKOMED Konin" },
                new Client { Name = "Centrum Zdrowia Psychicznego" },
                new Client { Name = "MEDALKO Rehabilitacja" }

            };

            foreach (Client client in clients)
            {
                if (dbContext.Client.FirstOrDefault<Client>(i => i.Name == client.Name) == null) dbContext.Client.Add(client);
            }

            dbContext.SaveChanges();
            
            return Task.FromResult(0);
        }
    }
}
