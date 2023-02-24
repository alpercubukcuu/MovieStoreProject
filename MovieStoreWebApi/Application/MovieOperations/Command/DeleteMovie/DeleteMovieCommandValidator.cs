using FluentValidation;


namespace MovieStoreWebApi.MovieOperations.DeleteMovie
{
   public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
   {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);

        }
   }
}