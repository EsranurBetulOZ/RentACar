using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Arac_Kiralama.Models.Entity;

public sealed class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

}
