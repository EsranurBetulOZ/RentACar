﻿using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Abstracts;

public interface IFuelRepository:IRepository<Fuel,int>
{
    bool ExistByFuelName(string name);
}
