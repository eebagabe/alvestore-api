using Alvestore.Api.Entities;

namespace Alvestore.Api.Interfaces;

public interface IUserRepository
{
    Task<bool> EmailExistsAsync(string email);
    Task AddAsync(User user);
}
