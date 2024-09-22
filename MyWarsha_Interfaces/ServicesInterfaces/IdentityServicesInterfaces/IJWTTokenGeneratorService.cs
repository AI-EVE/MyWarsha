using MyWarsha_Models.Models;

namespace MyWarsha_Interfaces.ServicesInterfaces.IdentityServicesInterfaces
{
    public interface IJWTTokenGeneratorService
    {
        string GenerateJwtToken(AppUser user);
    }
}