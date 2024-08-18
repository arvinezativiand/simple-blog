using Codeyad.DataLayer.Entities;

namespace Codeyad.CoreLayer.DTOs.Users;

public class UserDTO
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public UserRole Role { get; set; }
}
