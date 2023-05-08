using DAL;
using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IOrdersDbContext).Assembly));
});
builder.Services.AddOrdersCommandsService();
builder.Services.AddOrdersQueriesService();
builder.Services.AddOrderRepository();
builder.Services.OrdersDbContext(
    builder.Configuration.GetConnectionString("Orders"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Services.CreateScope()
    .ServiceProvider
    .GetRequiredService<OrdersDbContext>()
    .Database
    .Migrate();

app.Run();