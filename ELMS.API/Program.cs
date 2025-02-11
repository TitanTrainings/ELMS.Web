using ELMS.API.Data;
using ELMS.API.Mapper;
using ELMS.API.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register the dependency injection services
builder.Services.AddDependecyInjectionServices();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(LeaveRequestMapper));
builder.Services.AddAutoMapper(typeof(UserMapper));


//write the code to register the JWT token services


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAllOrigins");
    app.UseSwagger();  // To generate Swagger JSON
    app.UseSwaggerUI();  // To serve Swagger UI for interactive documentation
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
