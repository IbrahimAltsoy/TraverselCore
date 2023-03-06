using DtoLayer.DTOs.ContactDTOs;
using EntityLayer.Concreate;
using FluentValidation;

namespace BusiinessLayer.ValidationRules.ContactUsValidator
{
    public class SendContactValidator : AbstractValidator<SendMessageDto>
    {
        
        public SendContactValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Başlık kısmını lütfen doldurunuz...!")
                    .MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz...!")
                    .MaximumLength(50).WithMessage("Lütfen 50 karakterden az değer giriniz...!")
                     .WithName("Ad");
            RuleFor(x => x.Mail)
                    .NotEmpty().WithMessage("Açıklama kısmını lütfen doldurunuz...!")
                    .MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz...!")
                    .MaximumLength(60).WithMessage("Lütfen 60 karakterden az değer giriniz...!")
                    .WithName("Mail");
            RuleFor(x => x.Subject)
                    .NotEmpty().WithMessage("Açıklama kısmını lütfen doldurunuz...!")
                    .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz...!")
                    .MaximumLength(500).WithMessage("Lütfen 500 karakterden az değer giriniz...!")
                     .WithName("Başlık");
            RuleFor(x => x.MessageBody)
                    .NotEmpty().WithMessage("Açıklama kısmını lütfen doldurunuz...!")
                    .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz...!")
                    .MaximumLength(500).WithMessage("Lütfen 500 karakterden az değer giriniz...!")
                    .WithName("Mesaj İçeriği");
           
        }
    }
}
