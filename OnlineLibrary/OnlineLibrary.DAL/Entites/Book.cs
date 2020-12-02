using DataAnnotationsExtensions;
using System.Collections.Generic;

namespace OnlineLibrary.DAL.Entites
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }

        [Min(0)]
        public int QuantityInStock { get; set; }
        public List<BookUser> BookUsers { get; set; } = new List<BookUser>();

    }
}
