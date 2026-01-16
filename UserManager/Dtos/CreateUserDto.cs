using System.ComponentModel.DataAnnotations;

namespace UserManager.Dtos
{
    public record CreateUserDto(
    [Required] string Fullname,
    [Required] int Age,
    [Required] string Email,
    [Required] string Password,
    [Required] int Role);
}