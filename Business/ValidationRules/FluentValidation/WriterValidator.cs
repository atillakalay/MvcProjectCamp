using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(p => p.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(p => p.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(p => p.WriterAbout).NotEmpty().WithMessage("Hakkımdayı boş geçemezsiniz");
            RuleFor(p => p.WriterTitle).NotEmpty().WithMessage("Ünvanı boş geçemezsiniz");

            RuleFor(p => p.WriterSurName).MinimumLength(3).WithMessage("En az 3 karekter girişi yapın");
            RuleFor(p => p.WriterSurName).MaximumLength(20).WithMessage("Maksimum 20 karekter !");

        }
    }
}
