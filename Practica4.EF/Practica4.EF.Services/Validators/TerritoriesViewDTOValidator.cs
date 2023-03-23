using FluentValidation;
using Practica4.EF.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.EF.Services.Validators
{
    public class TerritoriesViewDTOValidator : AbstractValidator<TerritoriesViewDTO>
    {
        public TerritoriesViewDTOValidator()
        {
            RuleFor(x => x.ID).Length(1, 20).WithMessage("El ID debe tener entre 1 y 20 caracteres.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("La descripción es obligatoria.");
            RuleFor(x => x.Description).Length(1, 50).WithMessage("La descripción debe tener entre 1 y 50 caracteres.");
        }
    }
}
