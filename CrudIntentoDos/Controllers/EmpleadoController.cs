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
    public class EmpleadoController : ControllerBase
    {
        private ICrudService<EmpleadoDto, EmpleadoInsertDto, EmpleadoUpdateDto> _empleadoService;

        public EmpleadoController([FromKeyedServices("EmpleadoService")] ICrudService<EmpleadoDto, EmpleadoInsertDto, EmpleadoUpdateDto> empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmpleadoDto>> GetEmpleados() =>
            await _empleadoService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleadoById(int id)
        {
            var empleadoDto = await _empleadoService.GetById(id);

            return empleadoDto == null ? NotFound() : Ok(empleadoDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> AddEmpleado(EmpleadoInsertDto empleadoInsertDto) {
            var empleadoDto = await _empleadoService.Add(empleadoInsertDto);

            return CreatedAtAction(nameof(GetEmpleadoById), new { id = empleadoDto.EmpleadoId }, empleadoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoDto>> UpdateEmpleado(int id, EmpleadoUpdateDto empleadoUpdateDto)
        {
            var empleadoDto = await _empleadoService.Update(id, empleadoUpdateDto);

            return empleadoDto == null ? NotFound() : Ok(empleadoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpleadoDto>> DeleteEmpleado(int id)
        {
            var empleadoDto = await _empleadoService.Delete(id);

            return empleadoDto == null ? NotFound() : Ok(empleadoDto);
        }
    }
}
