using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Concretes
{
    public class FuelRepository(BaseDbContext context) : IFuelRepository
    {
        public Fuel Add(Fuel fuel)
        {

            fuel.CreatedDate = DateTime.UtcNow;
            context.Fuels.Add(fuel);
            context.SaveChanges();
            return fuel;
        }

        public Fuel Delete(Fuel fuel)
        {
            context.Fuels.Remove(fuel);
            context.SaveChanges();
            return fuel;
        }

        public bool ExistByFuelName(string name)
        {
            return context.Fuels.Any(x => x.Name == name);
        }

        public List<Fuel> GetAll()
        {
            return context.Fuels.ToList();
        }

        public Fuel GetById(int id)
        {
            return context.Fuels.Find(id);
        }

        public Fuel Update(Fuel fuel)
        {
            fuel.UpdatedDate = DateTime.UtcNow;
            context.Fuels.Update(fuel);
            context.SaveChanges();
            return fuel;
        }
    }
}
