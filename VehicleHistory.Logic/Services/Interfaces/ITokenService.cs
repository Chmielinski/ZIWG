using System.Threading.Tasks;

namespace VehicleHistory.Logic.Services.Interfaces
{
    public interface ITokenService
    {
        Task<bool> IsCurrentActiveToken();
        Task DeactivateCurrentAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
    }
}
