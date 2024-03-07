using Aplication.Dtos.Response;
using FluentValidation;

namespace Domain.Validacion
{
    public class ProductoDtoValidador : AbstractValidator<ProductoDto>
	{
		public ProductoDtoValidador()
		{
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .Length(1, 100).WithMessage("El nombre no debe exceder los 100 caracteres.");

            RuleFor(p => p.Descripcion)
                .Length(0, 500).WithMessage("La descripción no debe exceder los 500 caracteres.");

            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(1).WithMessage("El stock debe ser al menos 1.");

            RuleFor(p => p.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");

            RuleFor(p => p.TipoProducto)
               .NotNull().WithMessage("El tipo de producto es obligatorio.");
        }
	}
}

