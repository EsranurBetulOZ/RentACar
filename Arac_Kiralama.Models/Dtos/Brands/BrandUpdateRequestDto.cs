using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Brands;

public sealed record class BrandUpdateRequestDto(int Id ,string Name, string ModelYear);

