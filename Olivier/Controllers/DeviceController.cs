using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olivier.Dto;
using Olivier.Folder;
using Olivier.Service;

namespace Olivier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _DeviceService;
        public DeviceController(IDeviceService ForkService)
        {
            _DeviceService = ForkService;
        }
        // GET: api/Spoons
        [HttpGet("get-all-Fork")]
        public async Task<IActionResult> GetAllDevice()
        {
            var result = await _DeviceService.GetAllDevicesAsync();
            return StatusCode(result.ResponseCode, result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            var response = await _DeviceService.GetDeviceByIdAsync(id);

            // Handle different response codes from the service
            if (response.ResponseCode == 200)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(response.ResponseCode, response);
            }
        }
        [HttpPut("update-Device-record")]
        public async Task<IActionResult> UpdateAnimal([FromBody] DeviceUpdate req, int id)
        {
            var result = await _DeviceService.UpdateDeviceAsync(req, id);
            return StatusCode(result.ResponseCode, result);

        }
    }
}
