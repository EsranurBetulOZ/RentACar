using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Models.Dtos.Users;
using Arac_Kiralama.Models.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, BrandResponseDto>();
            CreateMap<BrandAddRequestDto, Brand>();
            CreateMap<BrandUpdateRequestDto, Brand>();

            CreateMap<Color, ColorResponseDto>();
            CreateMap<ColorAddRequestDto, Color>();
            CreateMap<ColorUpdateRequestDto, Color>();

            CreateMap<Transmission, TransmissionResponseDto>();
            CreateMap<TransmissionAddRequestDto, Transmission>();
            CreateMap<TransmissionUpdateRequestDto, Transmission>();


            CreateMap<Fuel, FuelResponseDto>();
            CreateMap<FuelAddRequestDto, Fuel>();
            CreateMap<FuelUpdateRequestDto, Fuel>();

            CreateMap<Car, CarResponseDto>();
            CreateMap<CarAddRequestDto, Car>();
            CreateMap<CarUpdateRequestDto, Car>();

            CreateMap<RegisterRequestDto, User>();
            CreateMap<User, UserResponseDto>();
         
            //CreateMap<RegisterViewModel, RegisterRequestDto>();
            //CreateMap<LoginViewModel, LoginRequestDto>();

        }
    }
}
