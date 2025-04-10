using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity;
public abstract class Entity<TId>
{
    protected Entity()
    {

    }
    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

}
