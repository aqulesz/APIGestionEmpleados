using APIGestionEmpleados.Validators;
using CrudIntentoDos.DTOs;
using CrudIntentoDos.Models;
using CrudIntentoDos.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedScoped<ICrudService<SucursalDto, SucursalInsertDto, SucursalUpdateDto>, SucursalService>("SucursalService");
builder.Services.AddKeyedScoped<ICrudService<EmpleadoDto, EmpleadoInsertDto, EmpleadoUpdateDto>, EmpleadoService>("EmpleadoService");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Entity Framework Inyectado
builder.Services.AddDbContext<GestionEmpleadoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestionEmpleadosCS"));
});

//Validators
builder.Services.AddScoped<IValidator<SucursalInsertDto>, SucursalInsertValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
