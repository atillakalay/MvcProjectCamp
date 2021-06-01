using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("Konuyu geçemezsiniz");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı Adını boş geçemezsiniz");
            RuleFor(p => p.Subject).MinimumLength(3).WithMessage("En az 3 karekter girişi yapın");
            RuleFor(p => p.UserName).MinimumLength(3).WithMessage("En az 3 karekter girişi yapın");
            RuleFor(p => p.Subject).MaximumLength(50).WithMessage("Maksimum 50 karekter !");
        }
    }
}
