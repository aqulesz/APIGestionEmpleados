using CrudIntentoDos.DTOs;
using CrudIntentoDos.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudIntentoDos.Services
{
    public class EmpleadoService : ICrudService<EmpleadoDto, EmpleadoInsertDto, EmpleadoUpdateDto>
    {
        private GestionEmpleadoContext _context;

        public EmpleadoService(GestionEmpleadoContext gestionEmpleadoContext)
        {
            _context = gestionEmpleadoContext;

        }

        public async Task<IEnumerable<EmpleadoDto>> Get() =>
            await _context.Empleados.Select(e => new EmpleadoDto
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Direccion = e.Direccion,
                SucursalId = e.SucursalId,
            }).ToListAsync();

        public async Task<EmpleadoDto> GetById(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                var empleadoDto = new EmpleadoDto
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Nombre = empleado.Nombre,
                    Apellido = empleado.Apellido,
                    Direccion = empleado.Direccion,
                    SucursalId = empleado.SucursalId,
                };

                return empleadoDto;
            }

            return null;
        }

        public async Task<EmpleadoDto> Add(EmpleadoInsertDto empleadoInsertDto)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoInsertDto.Nombre,
                Apellido = empleadoInsertDto.Apellido,
                Direccion = empleadoInsertDto.Direccion,
                SucursalId = empleadoInsertDto.SucursalId,
            };

            await _context.AddAsync(empleado);
            await _context.SaveChangesAsync();

            var empleadoDto = new EmpleadoDto
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Direccion = empleado.Direccion,
                SucursalId = empleado.SucursalId,
            };

            return empleadoDto;
        }

        public async Task<EmpleadoDto> Update(int id, EmpleadoUpdateDto empleadoUpdateDto)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                empleado.EmpleadoId = empleadoUpdateDto.EmpleadoId;
                empleado.Nombre = empleadoUpdateDto.Nombre;
                empleado.Direccion = empleadoUpdateDto.Direccion;
                empleado.SucursalId = empleado.SucursalId;

                await _context.SaveChangesAsync();

                var empeladoDto = new EmpleadoDto
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Nombre = empleado.Nombre,
                    Direccion = empleado.Direccion,
                    SucursalId = empleado.SucursalId,
                };

                return empeladoDto;
            }

            return null;
        }

        public async Task<EmpleadoDto> Delete(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                var empeladoDto = new EmpleadoDto
                {
                    EmpleadoId = empleado.EmpleadoId,
                    Nombre = empleado.Nombre,
                    Direccion = empleado.Direccion,
                    SucursalId = empleado.SucursalId,
                };

                _context.Remove(empleado);
                await _context.SaveChangesAsync();

                return empeladoDto;
            }

            return null;
        }
    }
}
