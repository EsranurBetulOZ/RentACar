using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Arac_Kiralama.Models.Entity;


public class Role : Entity<int>
{
    public Role()
    {
        Name = string.Empty;
        UserRoles = new List<UserRole>();
    }
    public string Name { get; set; }
    public List<UserRole> UserRoles { get; set; }
}
