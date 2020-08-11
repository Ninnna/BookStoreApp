using BookStoreApp.Core.Contract;
using BookStoreApp.Core.Model;
using BookStoreApp.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _db;
        public BookRepository(BookDbContext db)
        {
            _db = db;
        }
        public async Task<Book> CreateAsync(Book entry)
        {
            entry.TimePosted = DateTime.Now;
            _db.Books.Add(entry);
            return entry;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var data = await _db.Books.Where(x => x.BookId == id).FirstOrDefaultAsync();
            _db.Books.Remove(data);
            return id;
        }

        public async Task<Book> GetOneAsync(int id)
        {
            var data = await _db.Books.Where(x => x.BookId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<PagedResult<Book>> GetPagedAsync(BookCriteria criteria)
        {
            var data = await _db.Books.GetPagedAsync(criteria.Page, criteria.PageSize);
            return data;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(int id, Book entry)
        {
            var data = await _db.Books.Where(x => x.BookId == id).FirstOrDefaultAsync();
            data.TimePosted = DateTime.Now;
            data.Title = entry.Title;
            data.Category = entry.Category;
            return id;
        }
    }
}
