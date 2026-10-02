using System.ComponentModel.DataAnnotations;

namespace Alvestore.Api.DTOs;

public record CreateUserRequest(
    [Required, MaxLength(150)] string Name,
    [Required, EmailAddress, MaxLength(200)] string Email,
    [Required, MinLength(6)] string Password
);