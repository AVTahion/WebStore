using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using WebStore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreContextInitializer
    {
        private readonly WebStoreContext _db;

        public WebStoreContextInitializer(WebStoreContext db) => _db = db;

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync();
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
    }
}
