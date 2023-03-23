using FluentValidation;
using Practica4.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.EF.Services.Validators
{
    public class ShipperViewDTOValidator : AbstractValidator<ShipperViewDTO>
    {
        public ShipperViewDTOValidator() 
        {
            RuleFor(x => x.CompanyName).Length(1, 40).WithMessage("El nombre de la compania debe tener entre 1 y 40 caracteres.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("El nombre de la compania es obligatorio");
            RuleFor(x => x.Phone).Length(1, 24).WithMessage("El phone debe ser entre 1 y 24 caracteres");
        }
    }
}
