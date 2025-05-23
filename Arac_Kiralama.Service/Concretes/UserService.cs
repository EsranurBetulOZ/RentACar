﻿
using Arac_Kiralama.Models.Dtos.Users;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Service.Abstracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Arac_Kiralama.Service.Concretes;
public sealed class UserService(UserManager<User> userManager, IMapper mapper) : IUserService
{
    public async Task<UserResponseDto> CreateUserAsync(RegisterRequestDto register)
    {
        User user = mapper.Map<User>(register);
        var result = await userManager.CreateAsync(user, register.Password);

        if (!result.Succeeded)
        {
            // todo: ilgili hata alınırsa exception fırlat 
        }

        UserResponseDto dto = mapper.Map<UserResponseDto>(user);
        return dto;
    }

    public async Task<UserResponseDto> LoginAsync(LoginRequestDto login)
    {
        var user = await userManager.FindByEmailAsync(login.Email);
        if (user is null)
        {
            // todo: ilgili hata alınırsa exception fırlat 
        }

        var passwordIsMatch = await userManager.CheckPasswordAsync(user, login.Password);
        if (passwordIsMatch is false)
        {
            // todo: ilgili hata alınırsa exception fırlat 
        }

        UserResponseDto dto = mapper.Map<UserResponseDto>(user);
        return dto;
    }

    public async Task<UserResponseDto> GetByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            // todo: ilgili hata alınırsa exception fırlat 
        }
        UserResponseDto dto = mapper.Map<UserResponseDto>(user);
        return dto;
    }
}
