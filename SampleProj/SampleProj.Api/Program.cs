using Microsoft.AspNetCore.Identity;
using SampleProj.Api.Extensions;
using SampleProj.Api.Middlewares;
using SampleProj.Business.Extensions;
using SampleProj.Infrastructure.Extensions;
using static SampleProj.Business.Extensions.ServiceCollectionExtensions;
using static SampleProj.Infrastructure.Extensions.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
