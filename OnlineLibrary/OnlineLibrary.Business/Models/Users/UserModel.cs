using OnlineLibrary.Business.Models.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Business.Models.Users
{
    public class UserModel : BaseModel
    {
        public UserModel()
        {
            Books = new List<BookModel>();
        }

        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public List<BookModel> Books { get; set; }
    }
}
