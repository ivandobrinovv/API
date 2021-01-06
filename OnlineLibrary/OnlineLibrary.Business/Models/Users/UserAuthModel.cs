using OnlineLibrary.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Business.Models.Users
{
    public class UserAuthModel
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRoles Role { get; set; }
    }
}
