using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Entity
{
    public sealed class Car : Entity<Guid>
    {
        public Car()
        {
            Name = string.Empty;
            ImageUrl = string.Empty;
        }

        public string Name { get; set; }
        public int Kilometer { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; } = "/images/aksLogo.png";
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
    }
}
