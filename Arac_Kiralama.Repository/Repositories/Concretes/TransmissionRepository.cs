using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using CorePackage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Concretes
{
    public sealed class TransmissionRepository : EfRepositoryBase<Transmission, int, BaseDbContext>, ITransmissionRepository
    {
        public TransmissionRepository(BaseDbContext context) : base(context)
        {
        }

        public bool ExistByTransmissionName(string name)
        {
            return Context.Transmissions.Any(x => x.Name == name);
        }
    }
}
