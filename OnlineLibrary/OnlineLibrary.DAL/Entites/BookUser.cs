using System;

namespace OnlineLibrary.DAL.Entites
{
    public class BookUser
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
