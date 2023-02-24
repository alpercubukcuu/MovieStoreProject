using FluentValidation;

namespace MovieStoreWebApi.DirectorOperations.UpdateDirector
{
   public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
   {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.DirectorId).GreaterThan(0);
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
        }
   }
}