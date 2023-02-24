using FluentValidation;

namespace MovieStoreWebApi.MovieOperations.UpdateMovie
{
   public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
   {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Release_year).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
        }
   }
}