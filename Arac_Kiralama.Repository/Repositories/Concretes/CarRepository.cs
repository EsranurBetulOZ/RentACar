using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Concretes;

public sealed class CarRepository(BaseDbContext context) : ICarRepository
{
    public Car Add(Car car)
    {
        // İlişkili varlıkların varlığını kontrol et
        //var brandExists = context.Brands.Any(b => b.Id == car.BrandId);
        //var colorExists = context.Colors.Any(c => c.Id == car.ColorId);
        //var transmissionExists = context.Transmissions.Any(t => t.Id == car.TransmissionId);
        //var fuelExists = context.Fuels.Any(f => f.Id == car.FuelId);

        //if (!brandExists || !colorExists || !transmissionExists || !fuelExists)
        //{
        //    throw new InvalidOperationException("İlişkili varlıklardan biri veya birkaçı bulunamadı");
        //}

        car.CreatedDate = DateTime.UtcNow;
        context.Cars.Add(car);
        context.SaveChanges();
        return car;
    }

    public Car Delete(Car car)
    {
        context.Cars.Remove(car);
        context.SaveChanges();
        return car;
    }

    public List<Car> GetAll()
    {
        return context.Cars.ToList();
    }

    public Car GetById(Guid id)
    {
        return context.Cars.Find(id);
    }

    public Car Update(Car car)
    {
        car.UpdatedDate = DateTime.UtcNow;
        context.Cars.Update(car);
        context.SaveChanges();
        return car;
    }
}
