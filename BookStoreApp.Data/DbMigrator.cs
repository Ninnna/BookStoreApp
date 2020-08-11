using BookStoreApp.Core.Contract;
using BookStoreApp.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data
{
    public class DbMigrator : IDbMigrator
    {
        private readonly BookDbContext _db;
        public DbMigrator(BookDbContext db)
        {
            _db = db;
        }

        public async Task RunAsync()
        {
            if (!await AllMigrationsApplied())
            {
                Console.WriteLine("Migrating Database...");
                await _db.Database.MigrateAsync();
            }

            await this.SeedAsync();
        }

        private async Task SeedAsync()
        {
            if (_db.Books.Any())
            {
                return;
            }

            // add your code
           
            var books = new List<Book>
            {
                new Book {Title = "book1", Category = "music", TimePosted = DateTime.Now}
            };
            _db.Books.AddRange(books);

            await _db.SaveChangesAsync();
        }

        private async Task<bool> AllMigrationsApplied()
        {
            var histories = await _db.GetService<IHistoryRepository>()
                .GetAppliedMigrationsAsync();

            var applied = histories.Select(m => m.MigrationId);
            var total = _db.GetService<IMigrationsAssembly>().Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }
    }
}
