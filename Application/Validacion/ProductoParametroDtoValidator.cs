using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validacion
{
    public class ProductoParametroDtoValidator : AbstractValidator<ProductoParametroDto>
	{
		public ProductoParametroDtoValidator()
		{
            RuleFor(p => p.Nombre)
               .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
               .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");

            RuleFor(p => p.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(100).WithMessage("La descripción no debe exceder los 500 caracteres.");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(1).WithMessage("El stock debe ser al menos 1.");

            RuleFor(p => p.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");

            RuleFor(p => p.IdTipoProducto)
                .NotEmpty().WithMessage("El tipo de producto es obligatorio.");

            RuleFor(p => p.Estado)
                .NotNull().WithMessage("El estado del producto es obligatorio.");
        }
	}
}

