﻿using FluentValidation;

namespace CleanArchitecture.Application.SampleItems.Commands.CreateSampleItem;

public class CreateSampleItemCommandValidator : AbstractValidator<CreateSampleItemCommand>
{
    public CreateSampleItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
