using System.Collections.Generic;

namespace OnlineLibrary.DAL.Entites
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<BookUser> BookUsers { get; set; }
    }
}
