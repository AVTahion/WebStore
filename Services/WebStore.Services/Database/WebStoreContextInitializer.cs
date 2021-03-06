﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Services.Database
{
    public class WebStoreContextInitializer
    {
        private readonly ILogger<WebStoreContextInitializer> _logger;
        private readonly WebStoreContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public WebStoreContextInitializer(WebStoreContext db, UserManager<User> userManager, RoleManager<Role> roleManager, ILogger<WebStoreContextInitializer> logger)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync();

            await IdentityInitializeAsync();

            if (await _db.Products.AnyAsync()) return;
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                await _db.Sections.AddRangeAsync(TestData.Sections);
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Sections] ON");
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                transaction.Commit();
            }

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                await _db.Brands.AddRangeAsync(TestData.Brands);
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Brands] ON");
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                transaction.Commit();
            }

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                await _db.Products.AddRangeAsync(TestData.Products);
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Products] ON");
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Products] OFF");

                transaction.Commit();
            }
        }

        private async Task CheckRoleExist(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new Role { Name = roleName });
            }
        }

        private async Task IdentityInitializeAsync()
        {
            await CheckRoleExist(Role.Administrator);

            await CheckRoleExist(Role.User);

            if (await _userManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator,
                    //Email = "admin@server.com"
                };

                var creation_result = await _userManager.CreateAsync(admin, User.AdminPasswordDefault);

                if (creation_result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, Role.Administrator);
                }
                else
                {
                    var error = string.Join(",", creation_result.Errors.Select(e => e.Description));
                    _logger.LogError("Ошибка при создании пользователя Администратора в БД {0}", error);
                    throw new InvalidOperationException($"Ошибка при создании администратора в БД {error}");
                }
            }
        }
    }
}
