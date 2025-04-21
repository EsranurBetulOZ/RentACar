using Arac_Kiralama.Models.Entity;
using CorePackage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Abstracts
{
    public interface IColorRepository: IRepository<Color, int>
    {
        bool ExistByColorName(string name);
    }
}
