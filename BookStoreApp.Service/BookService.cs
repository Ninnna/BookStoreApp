using BookStoreApp.Core.Contract;
using BookStoreApp.Core.Model;
using BookStoreApp.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> CreateAsync(Book entry)
        {
            var result = await _bookRepository.CreateAsync(entry);
            await _bookRepository.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await _bookRepository.DeleteAsync(id);
            await _bookRepository.SaveChangesAsync();
            return result;
        }

        public async Task<Book> GetOneAsync(int id)
        {
            var result = await _bookRepository.GetOneAsync(id);
            return result;
        }

        public async Task<PagedResult<Book>> GetPagedAsync(BookCriteria criteria)
        {
            var result = await _bookRepository.GetPagedAsync(criteria);
            return result;
        }

        public async Task<int> UpdateAsync(int id, Book entry)
        {
            var result = await _bookRepository.UpdateAsync(id, entry);
            await _bookRepository.SaveChangesAsync();
            return result;
        }
    }
}
