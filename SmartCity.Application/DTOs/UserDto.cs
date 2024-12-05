using SmartCity.Domain.Entities;

namespace SmartCity.Application.DTOs;

public class UserDto {
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public UserDto(MUser user) {
        UserId = user.UserId;
        Username = user.Username;
        Email = user.Email;
        Avatar = user.Avatar.FileName;
    }
}
