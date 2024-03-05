using e_maktab.DataLayer.Context;
using e_maktab.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithToken();
builder.Services.AddDbContext<EMaktabContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("pgsql"));
});
builder.Services.AddService(builder.Configuration);
builder.Services
    .AddServices()
    .AddRepositories();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
