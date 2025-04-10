using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity
{
    public class UserRole : Entity<int>
    {
        public UserRole()
        {
            Role = new Role();
            User = new User();
        }

        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
