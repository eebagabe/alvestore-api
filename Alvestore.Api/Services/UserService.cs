using Alvestore.Api.DTOs;
using Alvestore.Api.Entities;
using Alvestore.Api.Exceptions;
using Alvestore.Api.Interfaces;

namespace Alvestore.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        if (await _userRepository.EmailExistsAsync(email))
            throw new ConflictException("Email already registered.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name.Trim(),
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _userRepository.AddAsync(user);

        return new UserResponse(user.Id, user.Name, user.Email, user.CreatedAt);
    }
}