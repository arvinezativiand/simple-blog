using Codeyad.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.DTOs.Users;

public class UserRegisteryDTO
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

}
