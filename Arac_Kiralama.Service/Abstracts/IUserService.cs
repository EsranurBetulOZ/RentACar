using Arac_Kiralama.Models.Dtos.Users;

namespace Arac_Kiralama.Service.Abstracts;

public interface IUserService
{
    Task<UserResponseDto> CreateUserAsync(RegisterRequestDto register);
    Task<UserResponseDto> LoginAsync(LoginRequestDto login);
    Task<UserResponseDto> GetByEmailAsync(string email);
}
