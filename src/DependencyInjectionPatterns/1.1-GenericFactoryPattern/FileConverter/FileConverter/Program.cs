using FileConverter.Factories;
using FileConverter.Interfaces;
using FileConverter.Models;
using FileConverter.Providers;
using FileConverter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<XmlFormatter>();
builder.Services.AddTransient<JsonFormatter>();
builder.Services.AddTransient(typeof(IFormatterFactory<>), typeof(FormatterFactor<>));

builder.Services.AddTransient<FormatterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/convert", (FormatterRequest request, FormatterService formatterService) =>
    {
        try
        {
            formatterService.FormatFile(request.FileName, request.Format);
            return Results.Ok(new { message = $"Successfully formatted {request.FileName} to {request.Format}" });
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    })
    .WithName("ConvertFile")
    .WithOpenApi();


app.Run();
