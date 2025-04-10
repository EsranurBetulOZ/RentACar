using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Cars;

public sealed record class CarUpdateRequestDto(Guid Id, string Name, int Kilometer, decimal DailyPrice, string ImageUrl, int BrandId, int ColorId, int TransmissionId, int FuelId);

