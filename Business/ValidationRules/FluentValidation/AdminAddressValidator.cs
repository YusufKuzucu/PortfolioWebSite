using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminAddressValidator:AbstractValidator<AdminAddress>
    {
        public AdminAddressValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi ekleyiniz");
           
        }
    }
}