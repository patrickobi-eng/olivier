using Olivier.Dto;

namespace Olivier.Service
{
    public interface IDeviceService
    {
        Task<ApiResponse> CreateDeviceAsync(DeviceCreate req);
        Task<ApiResponse> GetAllDevicesAsync();
        Task<ApiResponse> GetDeviceByIdAsync(int id);
        Task<ApiResponse> UpdateDeviceAsync(DeviceUpdate req, int id);
        Task<ApiResponse> DeleteDeviceByIdAsync(int id);

    }
}
