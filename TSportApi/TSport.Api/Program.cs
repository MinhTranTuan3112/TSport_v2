using TSport.Api.Middlewares;
using TSport.Api.Extensions;
using TSport.Api.BusinessLogic.Extensions;
using TSport.Api.DataAccess.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddApiDependencies(configuration)
                .AddBusinessLogicDependencies()
                .AddDataAccessDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
