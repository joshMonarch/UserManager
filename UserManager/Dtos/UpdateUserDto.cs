namespace UserManager.Dtos
{
    public record UpdateUserDto(
        string? Fullname,
        int? Age,
        string? Email,
        string? Password,
        int? Role
    );
}