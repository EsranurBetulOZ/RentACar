using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity;

public sealed class Transmission : Entity<int>
{
    public Transmission()
    {
        Name = string.Empty;
        Cars = new List<Car>();
    }


    public string Name { get; set; }

    public List<Car> Cars { get; set; }
}