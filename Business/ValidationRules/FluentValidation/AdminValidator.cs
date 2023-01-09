using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanını boş bırakmayınız");
            //RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad alanını boş bırakmayınız");
            //RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad en az 2 karakter olabilir");
            //RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Soyad en az 2 karakter olabilir");
            //RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir");
            //RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
            RuleFor(x => x.Password).MaximumLength(6).WithMessage("Şifre en az 8 karakter olmalı"); ;
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta alanı boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz");
        }
    }
}
