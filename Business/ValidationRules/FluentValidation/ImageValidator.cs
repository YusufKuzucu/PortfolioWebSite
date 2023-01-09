using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ImageValidator:AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x=>x.ImagePath).NotEmpty().WithMessage("Lütfen bir fotoğraf ekleyin");
            
        }
    }
}
