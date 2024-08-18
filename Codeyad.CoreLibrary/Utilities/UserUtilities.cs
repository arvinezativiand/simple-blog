using System.Security.Claims;

namespace Codeyad.CoreLayer.Utilities;

public static class UserUtilities
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentException(nameof(principal));

        return Convert.ToInt32(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
