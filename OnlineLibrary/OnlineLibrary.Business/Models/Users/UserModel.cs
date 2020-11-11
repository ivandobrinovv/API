using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Business.Models.Users
{
    public class UserModel : BaseModel
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
