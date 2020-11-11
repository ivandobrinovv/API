using System;

namespace OnlineLibrary.Business.Models.Books
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int QuantityInStock { get; set; }
    }
}
