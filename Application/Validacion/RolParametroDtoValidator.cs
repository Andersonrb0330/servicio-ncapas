using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validacion
{
    public class RolParametroDtoValidator : AbstractValidator<RolParametroDto>
    {
		public RolParametroDtoValidator()
		{
            RuleFor(r => r.Nombre)
             .NotEmpty().WithMessage("El nombre del rol es obligatorio.")
             .MaximumLength(100).WithMessage("El nombre no debe exceder los 50 caracteres.");
        }
	}
}

