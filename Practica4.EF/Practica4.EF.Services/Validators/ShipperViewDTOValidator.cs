using FluentValidation;
using Practica4.EF.Entities.DTO;

namespace Practica4.EF.Services.Validators
{
    public class ShipperViewDTOValidator : AbstractValidator<ShipperViewDTO>
    {
        public ShipperViewDTOValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("El identificador no puede estar vacio");
            RuleFor(x => x.CompanyName).Length(1, 40).WithMessage("El nombre de la compania debe tener entre 1 y 40 caracteres.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("El nombre de la compania es obligatorio");
            RuleFor(x => x.Phone).Length(0, 24).WithMessage("El phone debe ser entre 0 y 24 caracteres");
        }
    }
}
