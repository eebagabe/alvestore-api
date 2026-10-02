namespace Alvestore.Api.DTOs;

public record UserResponse(Guid id, string Name, string Email, DateTime CreatedAt);