using APIGestionEmpleados.Validators;
using CrudIntentoDos.DTOs;
using CrudIntentoDos.Models;
using CrudIntentoDos.Services;
using FluentValidation;
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
        private IValidator<SucursalInsertDto> _sucursalInsertValidator;

        public SucursalController([FromKeyedServices("SucursalService")] ICrudService<SucursalDto, SucursalInsertDto, SucursalUpdateDto> sucursalService,
            IValidator<SucursalInsertDto> sucursalInsertValidator)
        {
            _sucursalService = sucursalService;
            _sucursalInsertValidator = sucursalInsertValidator;
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
            var validationResult = await _sucursalInsertValidator.ValidateAsync(sucursalInsertDto);

           if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var sucursalDto = await _sucursalService.Add(sucursalInsertDto);

            return CreatedAtAction(nameof(GetSucursalById), new { id = sucursalDto.SucursalId}, sucursalDto);
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

