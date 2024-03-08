using Aplication.Dtos.Request;
using FluentValidation;

namespace Aplication.Validacion
{
    public class EmpresaParametroDtoValidator : AbstractValidator<EmpresaParametroDto>
	{
		public EmpresaParametroDtoValidator()
		{
            RuleFor(t => t.Nombre)
              .NotEmpty().WithMessage("El nombre de la empresa es obligatorio.")
              .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");
        }
	}
}

