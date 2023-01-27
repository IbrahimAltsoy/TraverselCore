using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusiinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Lütfen isim kısmını Yazınız!!!")
                .MinimumLength(3).WithMessage("Lütfen en 3 karakter isim giriniz...!")
                .MaximumLength(29).WithMessage("Lütfen 30 karakterden az değer giriniz...!");
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Lütfen açıklama kısmını Yazınız!!!")
               .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz...!")
                .MaximumLength(49).WithMessage("Lütfen 50 karakterden az değer giriniz...!");
                 
            RuleFor(x => x.Image)
               .NotEmpty().WithMessage("Lütfen resim adresini giriniz!!!");
            RuleFor(x => x.TwitterUrl)
               .NotEmpty().WithMessage("Lütfen Twitter adresini giriniz!!!");
            RuleFor(x => x.InstagramUrl)
               .NotEmpty().WithMessage("Lütfen Instagram adresini Yazınız!!!");



        }
    }
}
