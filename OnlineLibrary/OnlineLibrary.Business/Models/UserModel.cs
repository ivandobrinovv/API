using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLibrary.Business.Models
{
    public class UserModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
