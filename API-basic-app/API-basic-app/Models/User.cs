using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_basic_app.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
