using CrudIntentoDos.DTOs;
using CrudIntentoDos.Models;
using CrudIntentoDos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudIntentoDos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private ICrudService<SucursalDto, SucursalInsertDto, SucursalUpdateDto> _sucursalService;

        public SucursalController([FromKeyedServices("SucursalService")] ICrudService<SucursalDto, SucursalInsertDto, SucursalUpdateDto> sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet]
        public async Task<IEnumerable<SucursalDto>> GetEmpleados() =>
            await _sucursalService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDto>> GetSucursalById(int id)
        {
            var sucursalDto = await _sucursalService.GetById(id);

            return sucursalDto == null ? NotFound() : Ok(sucursalDto);
        }

        [HttpPost]
        public async Task<ActionResult<SucursalDto>> AddSucursal(SucursalInsertDto sucursalInsertDto)
        {
            var sucursalDto = _sucursalService.Add(sucursalInsertDto);

            return CreatedAtAction(nameof(GetSucursalById), new { id = sucursalDto.Id}, sucursalDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SucursalDto>> UpdateSucursal(int id, SucursalUpdateDto sucursalUpdateDto)
        {
            var sucursalDto = await _sucursalService.Update(id, sucursalUpdateDto);

            return sucursalDto == null ? NotFound() : Ok(sucursalDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SucursalDto>> DeleteSucursal(int id)
        {
            var sucursalDto = await _sucursalService.Delete(id);

            return sucursalDto == null ? NotFound() : Ok(sucursalDto);
        }
    }
}

