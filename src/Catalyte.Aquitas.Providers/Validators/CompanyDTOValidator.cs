﻿using Catalyte.Aquitas.DTOs.Company;
using FluentValidation;

namespace Catalyte.Aquitas.Providers.Providers
{
    public class CompanyDTOValidator : AbstractValidator<CompanyDTO>
    {
        public CompanyDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name is required.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name cannot be more than 50 characters.");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("The summary is required.");
        }
    }
}