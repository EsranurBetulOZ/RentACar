using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity;

    public class Color : Entity<int>
{
    public Color()
    {
        Name = string.Empty;
        Cars = new List<Car>();
    }

    public string Name { get; set; }
    public int RValue { get; set; }
    public int GValue { get; set; }
    public int BValue { get; set; }
    public List<Car> Cars { get; set; }

}
