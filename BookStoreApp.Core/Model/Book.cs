using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.Core.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime TimePosted { get; set; }
    }
}
