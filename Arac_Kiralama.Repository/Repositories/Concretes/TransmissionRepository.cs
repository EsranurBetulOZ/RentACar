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
    public class TransmissionRepository(BaseDbContext context) : ITransmissionRepository
    {
        public Transmission Add(Transmission transmission)
        {
            transmission.CreatedDate = DateTime.UtcNow;
            context.Transmissions.Add(transmission);
            context.SaveChanges();
            return transmission;
        }

        public Transmission Delete(Transmission transmission)
        {
            context.Transmissions.Remove(transmission);
            context.SaveChanges();
            return transmission;
        }

        public List<Transmission> GetAll()
        {
            return context.Transmissions.ToList();
        }

        public Transmission GetById(int id)
        {
            return context.Transmissions.Find(id);
        }

        public Transmission Update(Transmission transmission)
        {
            transmission.UpdatedDate = DateTime.UtcNow;
            context.Transmissions.Update(transmission);
            context.SaveChanges();
            return transmission;
        }
    }
}
