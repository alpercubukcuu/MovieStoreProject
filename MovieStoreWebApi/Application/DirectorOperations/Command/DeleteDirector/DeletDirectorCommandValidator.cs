using FluentValidation;


namespace MovieStoreWebApi.DirectorOperations.DeleteDirector
{
   public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
   {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(command => command.DirectorId).GreaterThan(0);

        }
   }
}