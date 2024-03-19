using System;
using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validacion
{
	public class DetalleRolEmpleadoDtoValidator : AbstractValidator<DetalleRolEmpleadoParametroDto>
    {
		public DetalleRolEmpleadoDtoValidator()
		{
            RuleFor(d => d.IdRol)
                .NotEmpty().WithMessage("El rol es obligatorio.");

            RuleFor(d => d.IdEmpleado)
                .NotEmpty().WithMessage("El empleado es obligatorio.");
        }
	}
}

