using Application.Extensions;
using ExternalServices.Extensions;
using Persistence.Extensions;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceProject(builder.Configuration);
builder.Services.AddApplicationProject();
builder.Services.AddExternalServiceProject(builder.Configuration);
builder.Services.AddWebApiProject(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// JWT seguridad
app.UseAuthentication();
app.UseAuthorization();
