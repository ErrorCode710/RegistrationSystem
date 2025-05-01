using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystem.Models
{
  
   public class Userdb
    {
        public string Role { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsRole(string role)
        {
            return Role.Equals(role, StringComparison.OrdinalIgnoreCase);
        }


    }
}
