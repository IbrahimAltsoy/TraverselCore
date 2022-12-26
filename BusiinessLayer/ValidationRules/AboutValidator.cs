using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.ValidationRules
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.TitleOne)
                .NotEmpty().WithMessage("Başlık kısmını lütfen doldurunuz...!")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz...!")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az değer giriniz...!")
                 .WithName("Başlık");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama kısmını lütfen doldurunuz...!")
                .MinimumLength(50).WithMessage("Lütfen en az 50 karakter giriniz...!")
                .MaximumLength(500).WithMessage("Lütfen 500 karakterden az değer giriniz...!")
                .WithName("Açıklama");
            RuleFor(x => x.TitleTwo)
                .NotEmpty().WithMessage("Açıklama kısmını lütfen doldurunuz...!")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz...!")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az değer giriniz...!")
                 .WithName("Başlık");
            RuleFor(x => x.DescriptionTwo)
                .NotEmpty().WithMessage("Açıklama kısmını lütfen doldurunuz...!")
                .MinimumLength(15).WithMessage("Lütfen en az 15 karakter giriniz...!")
                .MaximumLength(250).WithMessage("Lütfen 250 karakterden az değer giriniz...!")
                .WithName("Açıklama");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Bir görsel yükleyin...!")                
                .WithName("Resim");
        }
    }
}
