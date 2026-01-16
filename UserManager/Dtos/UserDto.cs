using System.ComponentModel.DataAnnotations;

namespace UserManager.Dtos
{
    public record UserDto(
        [Required] int Id,
        [Required] string Fullname,
        [Required] int Age,
        [Required] string Email,
        [Required] string Password,
        [Required] int Role,
        [Required] DateTime CreatedAt,
        [Required] DateTime UpdatedAt
    );
}