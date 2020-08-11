using BookStoreApp.Core.Model;
using BookStoreApp.Service;
using System;
using Xunit;

namespace BookServiceTest
{
    public class BookServiceTest
    {
        [Fact]
        public void GetOne_Return_Data()
        {
            //Arrange
            var svc = new BookService(new FakeBookRepository());

            //Act
            var actual = svc.GetOneAsync(1);

            //Assert
            var expected = new Book { Title = "book1", Category = "music", BookId = 1 };
            Assert.Equal(expected.Title, actual.Result.Title);
        }
    }
}
