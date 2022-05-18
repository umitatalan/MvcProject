using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında boş bırakılamaz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadı en az 2 karakter olmalıdır.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karakter olmalıdır.");
        }
    }
}
