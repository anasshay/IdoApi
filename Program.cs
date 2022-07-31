using Microsoft.EntityFrameworkCore;
using IdoApi.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdoContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("IdoContext")));

// add builder for cors with any origins
builder.Services.AddCors(options =>
{
  options.AddPolicy(MyAllowSpecificOrigins,
  builder =>
  {
    builder.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  //app.UseSwagger();
  //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
