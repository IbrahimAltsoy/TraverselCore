using DtoLayer.DTOs.ApUserDTOs;
using FluentValidation;


namespace BusiinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterAddDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez")
                .NotNull().WithMessage("Ad alanı boş geçilemez")
                .MinimumLength(3).WithMessage("En az 3 karakter olmalıdır.")
                .MaximumLength(30).WithMessage("En fazla 30 karakter olmalıdır.")
                .WithName("Kullanıcı");
            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage("Soyad alanı boş geçilemez")
                .NotNull().WithMessage("Soyad alanı boş geçilemez")
                .MinimumLength(3).WithMessage("En az 3 karakter olmalıdır.")
                .MaximumLength(30).WithMessage("En fazla 30 karakter olmalıdır.")
                .WithName("Soyad");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail alanı boş geçilemez")
                .NotNull().WithMessage("Mail alanı boş geçilemez")
                .MinimumLength(10).WithMessage("En az 10 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("En fazla 50 karakter olmalıdır.")
                .WithName("Email");
            RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez")
               .NotNull().WithMessage("Kullanıcı adı boş geçilemez")
               .MinimumLength(3).WithMessage("En az 3 karakter olmalıdır.")
               .MaximumLength(30).WithMessage("En fazla 30 karakter olmalıdır.")
               .WithName("Kullanıcı Adı");
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Şifre alanı boş geçilemez")
               .NotNull().WithMessage("Şifre alanı boş geçilemez")
               .MinimumLength(6).WithMessage("En az 6 karakter olmalıdır.")
               .MaximumLength(18).WithMessage("En fazla 18 karakter olmalıdır.")
               .WithName("Şifre");
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Şifre alanı boş geçilemez")
               .NotNull().WithMessage("Şifre alanı boş geçilemez")
               .MinimumLength(6).WithMessage("En az 6 karakter olmalıdır.")
               .MaximumLength(18).WithMessage("En fazla 18 karakter olmalıdır.")
               .WithName("Şifre");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("şifreler aynı olmalıdır. tekrar deneyiniz.");


        }
    }
}
