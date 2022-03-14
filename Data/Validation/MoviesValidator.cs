using ETicketsStore.Data.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Validation
{
    public class MoviesValidator : AbstractValidator<NewMovieVM>
    {
        public MoviesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required testing");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Movie Image URL is required");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start Date is required");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("End Date is required");
            RuleFor(x => x.MovieCategory).IsInEnum().WithMessage("Movie Category is required");
            RuleFor(x => x.ActorIds).NotEmpty().WithMessage("Movie actor(s) is required");
            RuleFor(x => x.CinemaId).NotEmpty().WithMessage("Cinema is required");
            RuleFor(x => x.ProducerId).NotEmpty().WithMessage("Producer is required");
        }
    }
}
