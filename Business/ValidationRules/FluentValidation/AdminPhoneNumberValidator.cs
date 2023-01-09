using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminPhoneNumberValidator : AbstractValidator<AdminPhoneNumber>
    {
        public AdminPhoneNumberValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen geçerli bir telefon numarası bilgisi ekleyiniz");
            RuleFor(x => x.PhoneNumber).MaximumLength(11).WithMessage("Telefon bilgisi en fazla 11 karakter olabilir");
            RuleFor(x => x.PhoneNumber).MinimumLength(11).WithMessage("Telefon bilgisi en az 11 karakter olabilir");
        }
    }
}
