using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApplication.Models.Validator
{
    public class NewRequestValidator:AbstractValidator<LOGIN.DATA.Models.UserClaim>
    {
        public NewRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("This field is required.");
            RuleFor(x => x.LastName).NotNull().WithMessage("This field is required.");
        }
    }
}
