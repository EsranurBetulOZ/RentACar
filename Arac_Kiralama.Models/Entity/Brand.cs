using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity;

public sealed class Brand : Entity<int>
{
    public Brand()
    {

        Name = string.Empty;
        Cars = new List<Car>();
    }

    public string Name { get; set; }
    public string ModelYear { get; set; }
    public List<Car> Cars { get; set; }
}
