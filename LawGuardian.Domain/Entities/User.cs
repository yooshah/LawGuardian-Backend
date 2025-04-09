using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Domain.Entities
{
    public class User
    {

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         
        public string Phone { get; set; }

        public string City {  get; set; }   

        public string State { get; set; }

        public string? ProfileImage { get; set; }

        public string UserType { get; set; }

        public bool IsBlocked { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } =DateTime.UtcNow;




    }
}
