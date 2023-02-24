using FluentValidation;
using MovieStoreWebApi.MovieOperations.CreateMovie;

namespace MovieStoreWebApi.CustomerOperations.CreateMovie
{
   public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
   {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Release_year).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
        }
   }
}