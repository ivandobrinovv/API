using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Business.Models.Users
{
    public class CreateUserModel : BaseModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
