using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen E-posta adresinizi giriniz") ;
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz") ;
            RuleFor(x => x.Message).NotEmpty().WithMessage("Lütfen Mesajınızı Yazınız");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("En az 10 karakter girmelisiniz");
            RuleFor(x => x.Message).MaximumLength(200).WithMessage("En fazla 200 karakter girmelisiniz");
        }
    }
}
