using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş bırakamazsınız");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu adı en fazla 50 karakter olmalıdır.");
        }
    }
}
