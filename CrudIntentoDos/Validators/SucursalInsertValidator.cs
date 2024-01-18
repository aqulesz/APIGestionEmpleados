using CrudIntentoDos.DTOs;
using FluentValidation;

namespace APIGestionEmpleados.Validators
{
    public class SucursalInsertValidator : AbstractValidator<SucursalInsertDto>
    {
        public SucursalInsertValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio");
            RuleFor(x => x.Nombre).Length(2, 20).WithMessage("El {PropertyName} debe tener entre 2 y 20 caracteres");
            RuleFor(x => x.Direccion).NotEmpty().WithMessage("El campo {PropertyName} es obligatorio");
            RuleFor(x => x.Direccion).Length(5, 50).WithMessage("El {PropertyName} debe tener entre 5 y 50 caracteres");
        }
    }
}
