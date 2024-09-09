using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Business.UserServ;
using MyApi.Business.CariServ;
using MyApi.Business.FinanceServ;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
serverOptions.Listen(System.Net.IPAddress.Any, 5000); 

//serverOptions.ListenLocalhost(5000); 
//serverOptions.Listen(System.Net.IPAddress.Parse("192.168.1.108"), 5000); 

});





builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CariService>();
builder.Services.AddScoped<FinanceService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseCors("AllowAll");

app.MapControllers();

app.Run();