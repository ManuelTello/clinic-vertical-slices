using Carter;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NET.Clinic.API.Contexts;
using NET.Clinic.API.Helpers.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection") ?? throw new ArgumentException();
var assembly = typeof(Program).Assembly;

builder.Services.AddOpenApi();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddCarter();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ExceptionHandler<,>));
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();
app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();
app.Run();