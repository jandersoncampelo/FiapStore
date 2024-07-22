using AutoMapper;
using FiapStore.Application;
using FiapStore.Infrastructure;
using FiapStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<ApplicationProfile>();
});

builder.Services.AddDbContext<FiapDbContext>(options =>
    options.UseInMemoryDatabase("FiapStore"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddInfrastructure();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();

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
