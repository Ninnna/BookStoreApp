using BookStoreApp.Core.Model;
using BookStoreApp.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.Contract
{
    public interface IBookRepository : IRepository
    {
        Task<PagedResult<Book>> GetPagedAsync(BookCriteria criteria);
        Task<Book> GetOneAsync(int id);
        Task<Book> CreateAsync(Book entry);
        Task<int> UpdateAsync(int id, Book entry);
        Task<int> DeleteAsync(int id);
    }
}
