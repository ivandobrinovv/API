using OnlineLibrary.DAL.Enums;
using System.Collections.Generic;

namespace OnlineLibrary.DAL.Entites
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public UserRoles Role { get; set; }
        public string Password { get; set; }
        public List<BookUser> BookUsers { get; set; } = new List<BookUser>();
    }
}
