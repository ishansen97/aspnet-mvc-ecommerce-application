using ETicketsStore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Validation
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithName("Actor Full Name")
                .WithMessage("Is required.")
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.Bio)
                .NotEmpty()
                .WithMessage("Bio is required");

            RuleFor(x => x.ProfilePictureURL)
                .NotEmpty()
                .WithMessage("Producer Profile Picture URL is required");
        }
    }
}
