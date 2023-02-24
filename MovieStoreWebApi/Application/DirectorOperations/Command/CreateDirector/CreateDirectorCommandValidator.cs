using FluentValidation;
using MovieStoreWebApi.DirectorOperations.CreateDirector;

namespace MovieStoreWebApi.DirectorOperations.CreateDirector
{
   public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
   {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
           
        }
   }
}