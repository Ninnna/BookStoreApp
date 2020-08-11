using BookStoreApp.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
