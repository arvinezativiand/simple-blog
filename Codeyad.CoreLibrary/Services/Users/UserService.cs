using Codeyad.CoreLayer.DTOs.Users;
using Codeyad.CoreLayer.Utilities;
using Codeyad.DataLayer.Context;
using Codeyad.DataLayer.Entities;


namespace Codeyad.CoreLayer.Services.Users;

public class UserService : IUserService
{
    private readonly BlogContext _context;
    public UserService(BlogContext context)
    {
        _context = context;
    }

    public UserDTO LoginUser(UserLoginDto loginDto)
    {
        string HsashedPassword = loginDto.Password.EncodeToMd5();
        var user = _context.Users.FirstOrDefault(u=> u.UserName==loginDto.UserName && u.Password==HsashedPassword);
        if (user == null)
            return null;

        return new UserDTO()
        {
            UserName = user.UserName,
            FullName = user.FullName,
            Password = user.Password,
            Id = user.Id,
            CreationDate = user.CreationDate,
            Role = user.Role
        };
        
               
    }

    public OperationResult RegisterUser(UserRegisteryDTO registerDto)
    {
        var UserNameResult = _context.Users.Any(u => u.UserName == registerDto.UserName);
        if (UserNameResult)
            return OperationResult.Error("نام کاربری تکراری است");

        var HasshedPassword = registerDto.Password.EncodeToMd5();
        _context.Users.Add(new User
        {
            FullName = registerDto.FullName,
            UserName = registerDto.UserName,
            Password = HasshedPassword,
            IsDelete = false,
            Role = UserRole.User,
            CreationDate = DateTime.Now,
        });
        _context.SaveChanges();
        return OperationResult.Success("عملیات موفقیت آمیز بود");

    }
}
