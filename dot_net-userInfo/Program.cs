using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using dot_net_userInfo.Models;
using dot_net_userInfo.Handlers;
using System.Configuration;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var MyAppOrigin = "MyAppOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAppOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader().AllowAnyMethod(); ;
                      });
});


var cs = builder.Configuration["ProjectDBConnectionString"];

builder.Services.AddDbContext<DbContext>(
    options => options.UseSqlServer(
        configuration.GetConnectionString(cs), x =>
                                    x.MigrationsAssembly("ProjectDB.Data")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("JwtSettings", options));

builder.Services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(builder.Configuration["JwtSettings:IssuerSigningKey"]));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAppOrigin);

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
