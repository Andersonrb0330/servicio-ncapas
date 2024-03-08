using Aplication.Dtos.Request;
using FluentValidation;

namespace Aplication.Validacion
{
    public class UsuarioParametroDtoValidator : AbstractValidator<UsuarioParametroDto>
    {
		public UsuarioParametroDtoValidator()
		{
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .Length(10, 50).WithMessage("El email debe tener entre 10 y 50 caracteres.");

            RuleFor(e => e.Clave)
                .NotEmpty().WithMessage("La clave es obligatorio.")
                .Length(5, 30).WithMessage("la clave debe tener entre 10 y 50 caracteres.");

            RuleFor(e => e.IdEmpleado)
                .NotEmpty().WithMessage("El ID del Empleado es obligatorio.");
        }
    }
}

