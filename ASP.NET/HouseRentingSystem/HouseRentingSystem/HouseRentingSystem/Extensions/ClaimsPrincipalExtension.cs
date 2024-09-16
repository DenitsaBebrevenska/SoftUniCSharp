using static HouseRentingSystem.Core.Constants.AdministratorConstants;
namespace System.Security.Claims;

public static class ClaimsPrincipalExtension
{
    public static string Id(this ClaimsPrincipal user)
    => user.FindFirstValue(ClaimTypes.NameIdentifier);

    public static bool IsAdmin(this ClaimsPrincipal user)
        => user.IsInRole(AdminRole);

}
