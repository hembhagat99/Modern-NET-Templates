using Microsoft.AspNetCore.Identity;
using ProjectName.Api.Extensions;
using ProjectName.Api.Middlewares;
using ProjectName.Business.Extensions;
using ProjectName.Infrastructure.Extensions;
using static ProjectName.Business.Extensions.ServiceCollectionExtensions;
using static ProjectName.Infrastructure.Extensions.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.RegisterSerilog();

builder.Services.RegisterStartupFilters();

builder.Services.RegisterAuthorization();

builder.Services.RegisterValidtors();
builder.Services.RegisterAutomapper();

builder.Services.RegisterServices();
builder.Services.RegisterRepositories(builder.Configuration);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

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

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseExceptionMiddleware();

app.MapGroup("api").MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();
