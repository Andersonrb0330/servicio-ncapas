using Aplication.Dtos.Request;
using FluentValidation;

namespace Aplication.Validacion
{
    public class EmpleadoParametroDtoValidator : AbstractValidator<EmpleadoParametroDto>
    {
        public EmpleadoParametroDtoValidator()
        {
            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                  .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");

            RuleFor(e => e.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");

            RuleFor(e => e.Edad)
                .NotEmpty().WithMessage("La edad es obligatoria.")
                .GreaterThanOrEqualTo(18).WithMessage("La edad debe ser mayor o igual a 18.");

            RuleFor(e => e.Dni)
                .NotEmpty().WithMessage("El DNI es obligatorio.")
                .Length(8).WithMessage("El DNI debe tener 8 caracteres.");

            RuleFor(e => e.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Length(7, 15).WithMessage("El teléfono debe tener entre 7 y 15 caracteres.");

            RuleFor(e => e.IdEmpresa)
                .NotEmpty().WithMessage("El ID de la empresa es obligatorio.");
        }
    }
}

