using Microsoft.EntityFrameworkCore;
using Olivier.Dto;
using Olivier.Folder;
using System.Runtime.CompilerServices;

namespace Olivier.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly AccessoryContext _context;
        

        public DeviceService(AccessoryContext context)
        {
            _context = context; // Assume DeviceDbContext handles database operations
        }

        public async Task<ApiResponse> CreateDeviceAsync(DeviceCreate req)
        {
              var result = new ApiResponse();
            try
            {
                //write dto to database
                var Device = new Device
                {
                    BrandName = req.BrandName,
                    colour = req.colour,
                    IsNew = req.IsNew
                };
                _context.Devices.AddAsync(Device);
                await _context.SaveChangesAsync();
                //prepare response to the client
                result.ResponseMessage="Created successfully";
                result.ResponseCode = 201;
                result.Data = Device.Id;

            }
            catch (Exception ex)
            {
                result.ResponseMessage="something went wrong";
                result.ResponseCode=500;
                result.Data = ex.Message;
            }
            return result;

        }

        public async Task<ApiResponse> DeleteDeviceByIdAsync(int id)
        {
            var result = new ApiResponse();
            try
            {
                var record  = await _context.Devices.FindAsync(id);
                if (record is not null)
                {
                    var rec = new DeviceDelete
                    {
                        Id = record.Id,
                        BrandName = record.BrandName,
                        colour = record.colour,
                        IsNew = record.IsNew
                    };
                    _context.Devices.Remove(record);
                    await _context.SaveChangesAsync();
                    //prepare responsecode for your client
                    result.ResponseMessage = "Deleted successfully";
                    result.ResponseCode = 204;
                    result.Data = record;
                }
                else
                {
                    result.ResponseCode = 404;
                    result.ResponseMessage = "Result not found";

                }

            }
            catch (Exception ex)
            {
                result.ResponseCode = 500;
                result.ResponseMessage = "server not found";
                result.Data=ex.Message;
            }
            return result;
        }

        public async Task<ApiResponse> GetAllDevicesAsync()
        {
            var result = new ApiResponse();
            try
            {
                var records = await _context.Devices.ToListAsync();
                if (records.Any())
                {
                    var res= records.Select(x => new DeviceResponse
                    {
                        Id = x.Id,
                        BrandName = x.BrandName,
                        colour = x.colour,
                        IsNew = x.IsNew
                    }).ToList();
                    result.ResponseMessage = "records retrieved successfully";
                    result.ResponseCode= 200;
                    result.Data = records;
                   
                }
                else
                {
                    result.ResponseCode = 204;
                    result.ResponseMessage = "No devices found";
                }

            }
            catch (Exception ex)
            {
                result.ResponseCode = 500;
                result.ResponseMessage = "server not found";
                result.Data = ex.Message;
            }
            return result;
        }

        public async Task<ApiResponse> GetDeviceByIdAsync(int id)
        {
            var result = new ApiResponse();
            try
            {
                var records = await _context.Devices.FindAsync(id);
                if (records == null) 
                {
                    var res =new DeviceResponse 
                    { 
                              Id = records.Id,
                       BrandName =records.BrandName,
                          colour = records.colour,
                           IsNew = records.IsNew
                    };
                    result.ResponseMessage = "retrieved successfully";
                    result.ResponseCode = 200;
                    result.Data = records;
                }
                else 
                {
                    result.ResponseMessage = "bad request";
                    result.ResponseCode = 400; 
                }
            }
            catch (Exception ex)
            {
                result.ResponseCode = 500;
                result.ResponseMessage = "not reachable";
                result.Data = ex.Message;
            }
             return result;
        }


        public async Task<ApiResponse> UpdateDeviceAsync(DeviceUpdate req, int id)
        {
            var result =new ApiResponse();
            try
            {
                var Device = await _context.Devices.FindAsync(id);
                if (Device is not null)
                {
               
                    
                         
                         Device.BrandName = req.BrandName;
                         Device.colour = req.colour;
                         Device.IsNew = req.IsNew;
                    
                    _context.Devices.Update(Device);
                    await _context.SaveChangesAsync();
                    result.ResponseMessage = "update successful";
                    result.ResponseCode = 200;
                    result.Data = req;
                }
                else 
                {
                    result.ResponseMessage = "Deviced not found";
                    result.ResponseCode = 404;
                }
            }
            catch (Exception ex)
            {
                result.ResponseCode = 500;
                result.ResponseMessage = "An error occured";
                result.Data = ex.Message;
            }
            return result;
        }
    }
}
