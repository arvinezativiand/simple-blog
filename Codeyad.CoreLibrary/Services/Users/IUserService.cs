using Codeyad.CoreLayer.DTOs.Users;
using Codeyad.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.Services.Users;

public interface IUserService
{
    OperationResult RegisterUser(UserRegisteryDTO registery);
    UserDTO LoginUser(UserLoginDto loginDto);
}
