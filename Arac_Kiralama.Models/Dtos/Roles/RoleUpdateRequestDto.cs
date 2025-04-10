using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Roles
{
    public sealed record class RoleUpdateRequestDto(int Id, string Name);
}
