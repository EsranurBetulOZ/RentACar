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
    public class ColorRepository(BaseDbContext context) : IColorRepository
    {
        public Color Add(Color color)
        {
            color.CreatedDate = DateTime.UtcNow;
            context.Colors.Add(color);
            context.SaveChanges();
            return color;
        }

        public Color Delete(Color color)
        {
            context.Colors.Remove(color);
            context.SaveChanges();
            return color;
        }

        public List<Color> GetAll()
        {
            return context.Colors.ToList();
        }

        public Color GetById(int id)
        {
            return context.Colors.Find(id);
        }

        public Color Update(Color color)
        {
            color.UpdatedDate = DateTime.UtcNow;
            context.Colors.Update(color);
            context.SaveChanges();
            return color;
        }
    }
}
