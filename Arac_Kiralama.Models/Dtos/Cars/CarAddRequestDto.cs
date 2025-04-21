using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Cars;

public sealed record class CarAddRequestDto
{
    public string Name { get; set; } = string.Empty;
    public int Kilometer { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public IFormFile? File { get; set; }
}
