using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Users;

public sealed class LoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
