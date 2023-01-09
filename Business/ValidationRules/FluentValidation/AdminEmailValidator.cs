using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminEmailValidator:AbstractValidator<AdminEmail>
    {
        public AdminEmailValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Lütfen geçerli bir email bilgisi ekleyiniz");
        }
    }
}
