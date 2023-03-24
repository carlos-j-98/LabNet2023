using FluentValidation;
using Practica4.EF.Entities.DTO;

namespace Practica4.EF.Services.Validators
{
    public class TerritoriesViewDTOValidator : AbstractValidator<TerritoriesViewDTO>
    {
        public TerritoriesViewDTOValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("El identificador no puede estar vacio");
            RuleFor(x => x.ID).Length(1, 20).WithMessage("El ID debe tener entre 1 y 20 caracteres.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("La descripción es obligatoria.");
            RuleFor(x => x.Description).Length(0, 50).WithMessage("La descripción debe tener entre 0 y 50 caracteres.");
        }
    }
}
