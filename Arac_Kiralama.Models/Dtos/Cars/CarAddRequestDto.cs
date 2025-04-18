﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Cars;

public sealed record class CarAddRequestDto(string Name, int Kilometer, decimal DailyPrice, string ImageUrl, int BrandId, int ColorId, int TransmissionId, int FuelId, IFormFile? File)
{
    // Parametre almayan constructor ekleyin
    public CarAddRequestDto() : this("", 0, 0, "", 0, 0, 0, 0, null) { }
};