using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class IconValidator:AbstractValidator<Icon>
    {
        public IconValidator()
        {
            RuleFor(x => x.IconName).NotEmpty().WithMessage("icon adı boş geçilemez");
            
        }
    }
}
