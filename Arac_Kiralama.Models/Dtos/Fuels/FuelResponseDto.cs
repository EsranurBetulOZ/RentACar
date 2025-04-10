using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Fuels;

public sealed record class FuelResponseDto(int Id, string Name,  DateTime CreatedDate, DateTime? UpdatedDate);
