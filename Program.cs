using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using QuotesAPI.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuotesContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnStr")));

var app = builder.Build();

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:7121", "https://localhost:7121").AllowAnyMethod().AllowAnyOrigin()
        .AllowAnyHeader().WithHeaders(HeaderNames.ContentType);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();