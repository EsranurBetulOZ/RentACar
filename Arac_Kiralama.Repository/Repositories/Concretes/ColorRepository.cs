using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using CorePackage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Concretes;



public sealed class ColorRepository : EfRepositoryBase<Color, int, BaseDbContext>, IColorRepository
{
    public ColorRepository(BaseDbContext context) : base(context)
    {
    }

    public bool ExistByColorName(string name)
    {
        return Context.Colors.Any(x => x.Name == name);
    }
}
