using Microsoft.EntityFrameworkCore;
using Olivier.Folder;
using Olivier.Service;
using Olivier.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.AddDbContext<AccessoryContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"), sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure();
        ; // Enable trust on the certificate
    });
});


builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IGadgetService, GadgetService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
