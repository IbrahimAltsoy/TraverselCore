using DtoLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDto>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez")
                .NotNull().WithMessage("Ad alanı boş geçilemez")
                .MinimumLength(5).WithMessage("En az 5 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("En fazla 50 karakter olmalıdır.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez")
                .NotNull().WithMessage("Ad alanı boş geçilemez")
                .MinimumLength(15).WithMessage("En az 15 karakter olmalıdır.")
                .MaximumLength(250).WithMessage("En fazla 250 karakter olmalıdır.");
        }
    }
}
