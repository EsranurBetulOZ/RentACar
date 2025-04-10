using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity;

public sealed class User : Entity<Guid>
{
    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Username = string.Empty;
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSAlt = Array.Empty<byte>();
        UserRoles = new List<UserRole>();

    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSAlt { get; set; }
    public bool Status { get; set; }
    public List<UserRole> UserRoles { get; set; }
}
