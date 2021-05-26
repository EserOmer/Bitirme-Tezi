using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(u => u.NAME).NotEmpty();
            RuleFor(u => u.QUESTION_TYPE_ID).NotEmpty();
            RuleFor(u => u.NAME).MaximumLength(250);
        }
    }
}
