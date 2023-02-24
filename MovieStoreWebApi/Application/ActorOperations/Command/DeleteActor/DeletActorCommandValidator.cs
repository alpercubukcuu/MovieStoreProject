using FluentValidation;


namespace MovieStoreWebApi.ActorOperations.DeleteActor
{
   public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
   {
        public DeleteActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);

        }
   }
}