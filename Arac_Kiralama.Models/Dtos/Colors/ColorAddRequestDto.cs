﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Models.Dtos.Colors;

public sealed record class ColorAddRequestDto(string Name,int RValue,int GValue,int BValue);

