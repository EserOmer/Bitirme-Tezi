using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FormValidator : AbstractValidator<Form>
    {
        public FormValidator()
        {
            RuleFor(u => u.FORM_TYPE).NotEmpty();
            RuleFor(u => u.USER_ID).NotEmpty();
            RuleFor(u => u.FORM_STATUS).NotEmpty();
        }
    }
}
