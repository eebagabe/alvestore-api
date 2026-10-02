using Alvestore.Api.DTOs;

namespace Alvestore.Api.Interfaces;

public interface IUserService
{
    Task<UserResponse> CreateAsync(CreateUserRequest request);
}