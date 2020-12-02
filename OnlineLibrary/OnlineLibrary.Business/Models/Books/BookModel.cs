using DataAnnotationsExtensions;
using System;

namespace OnlineLibrary.Business.Models.Books
{
    public class BookModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        [Min(0)]
        public int QuantityInStock { get; set; }
    }
}
