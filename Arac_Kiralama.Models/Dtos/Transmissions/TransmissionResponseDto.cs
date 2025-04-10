using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Transmissions;

public sealed record class TransmissionResponseDto(string Id,string Name, DateTime CreatedDate, DateTime? UpdatedDate);

