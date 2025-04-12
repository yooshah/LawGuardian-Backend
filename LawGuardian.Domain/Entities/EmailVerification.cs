using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Domain.Entities
{
    public class EmailVerification
    {


        public Guid Id { get; set; }
        public string Email { get; set; }   
        public string Otp {  get; set; }    
        public DateTime ExpireTime { get; set; }

        public bool IsValidated { get; set; }
        public bool IsUsed { get; set; }

        public DateTime CreatedAt { get; set; }

        


    }
}
