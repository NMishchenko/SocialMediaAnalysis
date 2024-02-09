/*
using FluentValidation;
using SocialMediaAnalysis.BLL.Models.SomeModel;

namespace SocialMediaAnalysis.BLL.Validators.SomeModel;

public class SomeModelValidator : AbstractValidator<SomeModel>
{
    public SomeModelValidator()
    {
        RuleFor(model => model.Name).NotEmpty().Length(3, 100);
        RuleFor(model => model.Description).NotEmpty().MaximumLength(255);
        RuleFor(model => model.Key).NotEmpty().Length(3, 100);
        RuleFor(model => model.Price).NotNull().InclusiveBetween(0.0m, 100000.0m);
        RuleFor(model => model.UnitsInStock).NotNull().InclusiveBetween((ushort)0, (ushort)65535);
    }
}

THIS IS AN EXAMPLE OF THE VALIDATOR

*/