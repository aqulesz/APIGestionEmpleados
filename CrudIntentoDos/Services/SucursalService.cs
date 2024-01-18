using CrudIntentoDos.DTOs;
using CrudIntentoDos.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudIntentoDos.Services
{
    public class SucursalService : ICrudService<SucursalDto, SucursalInsertDto, SucursalUpdateDto>
    {
        private GestionEmpleadoContext _context;

        public SucursalService(GestionEmpleadoContext gestionEmpleadoContext)
        {
            _context = gestionEmpleadoContext;

        }

        public async Task<IEnumerable<SucursalDto>> Get() => 
            await _context.Sucursales.Select(s => new SucursalDto
            {
                SucursalId = s.SucursalId,
                Nombre = s.Nombre,
                Direccion = s.Direccion,
            }).ToListAsync();

        public async Task<SucursalDto> GetById(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal != null)
            {
                var sucursalDto = new SucursalDto
                {
                    SucursalId = sucursal.SucursalId,
                    Nombre = sucursal.Nombre,
                    Direccion = sucursal.Direccion,
                };

                return sucursalDto;
            }

            return null;
        }

        public async Task<SucursalDto> Add(SucursalInsertDto sucursalInsertDto)
        {
            var sucursal = new Sucursal
            {
                Nombre = sucursalInsertDto.Nombre,
                Direccion = sucursalInsertDto.Direccion,

            };

            await _context.AddAsync(sucursal);
            await _context.SaveChangesAsync();

            var sucursalDto = new SucursalDto
            {
                SucursalId = sucursal.SucursalId,
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
            };

            return sucursalDto;
        }

        public async Task<SucursalDto> Update(int id, SucursalUpdateDto sucursalUpdateDto)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal != null)
            {
                sucursal.SucursalId = sucursalUpdateDto.SucursalId;
                sucursal.Nombre = sucursalUpdateDto.Nombre;
                sucursal.Direccion = sucursalUpdateDto.Direccion;

                await _context.SaveChangesAsync();

                var sucursalDto = new SucursalDto
                {
                    SucursalId = sucursal.SucursalId,
                    Nombre = sucursal.Nombre,
                    Direccion = sucursal.Direccion,
                };

                return sucursalDto;
            }

            return null;
        }

        public async Task<SucursalDto> Delete(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal != null)
            {
                var sucursalDto = new SucursalDto
                {
                    SucursalId = sucursal.SucursalId,
                    Nombre = sucursal.Nombre,
                    Direccion = sucursal.Direccion,
                };

                _context.Remove(sucursal);
                await _context.SaveChangesAsync();

                return sucursalDto;
            }

            return null;
        }
    }
}
