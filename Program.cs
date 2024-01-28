using SuperheroApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add CORS policy too allow the react app to query the api
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowOrigin", builder =>
   {
      builder.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
   });
});


// add memory cache service
builder.Services.AddMemoryCache();

// connect the db
builder.Services.AddDbContext<SuperHeroContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("constring"));
});

var app = builder.Build();

// configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// use CORS policy
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
