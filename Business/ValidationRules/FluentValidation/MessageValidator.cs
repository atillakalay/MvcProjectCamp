using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(p => p.Subject).MinimumLength(3).WithMessage("En az 3 karekter girişi yapın");
            RuleFor(p => p.ReceiverMail).MinimumLength(3).WithMessage("En az 3 karekter girişi yapın");
            RuleFor(p => p.Subject).MaximumLength(50).WithMessage("Maksimum 50 karekter !");
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
