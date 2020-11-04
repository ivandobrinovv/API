using System.Collections.Generic;

namespace OnlineLibrary.DAL.Entites
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int QuantityInStock { get; set; }
        public ICollection<BookUser> BookUsers { get; set; }

    }
}
