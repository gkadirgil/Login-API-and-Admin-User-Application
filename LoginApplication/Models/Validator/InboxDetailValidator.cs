using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.Models.Validator
{
    public class InboxDetailValidator: AbstractValidator<LOGIN.DATA.Models.UserClaim>
    {
        public InboxDetailValidator()
        {
            RuleFor(x=>x.AdminDescription).NotNull().WithMessage("This field is required.");
        }
    }
}
