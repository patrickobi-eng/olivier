using Olivier.Dto;

namespace Olivier.Services
{
    public interface IGadgetService
    {
        Task<ApiResponse> CreateGadget(GadgetCreate req);
        Task<ApiResponse> GetAllGadgetAsync();
        Task<ApiResponse> GetGadgetByIdAsync(int id);
        Task<ApiResponse> UpdateGadget(GadgetUpdate req);   
        Task<ApiResponse> DeleteGadget(int id);
    }
}
