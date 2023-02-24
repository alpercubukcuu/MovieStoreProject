using FluentValidation;
using MovieStoreWebApi.ActorOperations.CreateActor;

namespace MovieStoreWebApi.ActorOperations.CreateActor
{
   public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
   {
        public CreateActorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
           
        }
   }
}