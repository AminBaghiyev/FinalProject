using FinalProject.DL;
using FinalProject.BL;
using FinalProject.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDLServices();
builder.Services.AddBLServices();
builder.Services.AddAPIServices(
    builder.Configuration["JWT:SecretKey"],
    builder.Configuration["JWT:Audience"],
    builder.Configuration["JWT:Issuer"]
);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
