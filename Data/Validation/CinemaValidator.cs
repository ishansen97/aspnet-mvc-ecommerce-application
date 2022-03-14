using ETicketsStore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Validation
{
    public class CinemaValidator : AbstractValidator<Cinema>
    {
        public CinemaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Logo).NotEmpty().WithMessage("Logo URL is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
