using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validacion
{
    public class TipoProductoParametroDtoValidator : AbstractValidator<TipoProductoParametroDto>
	{
		public TipoProductoParametroDtoValidator()
		{
            RuleFor(t => t.Nombre)
			   .NotEmpty().WithMessage("El nombre del tipo producto es obligatorio.")
			   .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");
        }
	}
}

