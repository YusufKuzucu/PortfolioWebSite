using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MyServiceValidator:AbstractValidator<MyService>
    {
        public MyServiceValidator()
        {
            RuleFor(x=>x.ServiceName).NotEmpty().WithMessage("Lütfen bir hizmet adı giriniz");
            RuleFor(x=>x.ServiceName).MinimumLength(2).WithMessage("Hizmet adı en az 2 karakter olabilir");
            RuleFor(x=>x.ServiceName).MaximumLength(50).WithMessage("Hizmet adı en fazla 50 karakter olabilir");
            RuleFor(x=>x.ServiceIcon).NotEmpty().WithMessage("Lütfen sembol tablosundan yazmak istediğiniz sembol adını buraya yazınız");
        }
    }
}
