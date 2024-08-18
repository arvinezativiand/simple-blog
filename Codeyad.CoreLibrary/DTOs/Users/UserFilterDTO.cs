using Codeyad.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.DTOs.Users;
public class UserFilterDTO : BasePagination
{
    public List<UserDTO> Users { get; set; }
}
