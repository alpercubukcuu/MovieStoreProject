using FluentValidation;

namespace MovieStoreWebApi.ActorOperations.UpdateActor
{
   public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
   {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
        }
   }
}