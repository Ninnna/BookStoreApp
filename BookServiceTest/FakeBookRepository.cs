using BookStoreApp.Core.Contract;
using BookStoreApp.Core.Model;
using BookStoreApp.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookServiceTest
{
    public class FakeBookRepository : IBookRepository
    {
        public async Task<Book> CreateAsync(Book entry)
        {
            entry.BookId = 1;
            return entry;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return id;
        }

        public async Task<Book> GetOneAsync(int id)
        {
            return new Book { Title = "book1", Category = "music", BookId = id };
        }

        public async Task<PagedResult<Book>> GetPagedAsync(BookCriteria criteria)
        {
            var books =new List<Book> { new Book { Title = "book1", Category = "music", BookId = 1 } };
            var data = new PagedResult<Book>
            {
                CurrentPage = 1,
                PageCount = 1,
                PageSize = 10,
                RowCount = 1,
                Items = books
            };
            return data;
        }

        public async Task<int> SaveChangesAsync()
        {
            return 1;
        }

        public async Task<int> UpdateAsync(int id, Book entry)
        {
            return id;
        }
    }
}
