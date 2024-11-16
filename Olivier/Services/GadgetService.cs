using Olivier.Dto;
using Olivier.Folder;
using System.Drawing;
using System.Linq.Expressions;

namespace Olivier.Services
{
    public class GadgetService : IGadgetService
    {
        private readonly AccessoryContext await_context;
        private string colour;
        private bool isNew;

        public GadgetService(AccessoryContext context)
        {
            await_context = context;
        }

        public string BrandName { get; private set; }

        public async Task<ApiResponse> CreateGadget(GadgetCreate req)
        {
            var result = new ApiResponse();
            try
            {
                var Gadget = new Gadget
                {
                    BrandName = req.BrandName,
                    colour = req.colour,
                    IsNew = req.IsNew
                };
                await_context.Gadgets.AddAsync(Gadget);
                await await_context.SaveChangesAsync();
                result.ResponseMessage = "Created successfully";
                result.ResponseCode = 201;
                result.Data = Gadget.Id;

            }
            catch (Exception ex)
            {
                result.ResponseMessage = "something went wrong";
                result.ResponseCode = 500;
                result.Data = ex.Message;
            }
            return result;

        }

        public async Task<ApiResponse> DeleteGadget(int id)
        {
            var result = new ApiResponse();
            try
            {
                var record = await await_context.Gadgets.FindAsync(id);
                if (record is not null)
                {
                    var res = new GadgetDelete
                    {
                        Id = record.Id,
                        BrandName = record.BrandName,
                        colour = record.colour,
                        IsNew = record.IsNew,
                    };
                    await_context.Gadgets.Remove(record);
                    await await_context.SaveChangesAsync();
                    result.ResponseMessage = "Deleted successfully";
                    result.ResponseCode = 204;
                    result.Data = record;

                }
                else
                {
                    result.ResponseCode = 404;
                    result.ResponseMessage = "Gadget not found";
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

        public async Task<ApiResponse> GetAllGadgetAsync()
        {
            var result = new ApiResponse();
            try
            {
                var Gadgets = await_context.Gadgets.AsQueryable();

                if (Gadgets.Any())
                {
                    var records = Gadgets.Select(x => new GadgetResponse
                    {
                        Id = x.Id,
                        BrandName = x.BrandName,
                        colour = x.colour,
                        IsNew = x.IsNew
                    }).ToList();
                    result.ResponseMessage = "records retrieved successfully";
                    result.ResponseCode = 200;
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
        public async Task<ApiResponse> GetGadgetByIdAsync(int Id)
        {
            var result = new ApiResponse();
            try 
            {
                var records= await_context.Gadgets.FindAsync(Id);
                if(records ==null) 
                {
                    var res = new GadgetResponse
                    {
                        Id = Id,
                        BrandName =BrandName,
                        colour =colour,
                        IsNew = isNew   
                    };
                }
            }
            catch(Exception ex) 
            {
            }
            return result;
        }

        public Task<ApiResponse> UpdateGadget(GadgetUpdate req)
        {
            throw new NotImplementedException();
        }
    }
    
}
