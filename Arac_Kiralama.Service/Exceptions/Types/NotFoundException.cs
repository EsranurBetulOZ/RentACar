using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Exceptions.Types
{
    public class NotFoundException(string message):Exception(message)
    {
    }
}
