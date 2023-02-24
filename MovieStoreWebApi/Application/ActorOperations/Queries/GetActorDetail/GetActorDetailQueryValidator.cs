using FluentValidation;

namespace MovieStoreWebApi.ActorOperations.GetActorDetail
{
   public class GetActorDetailQeuryValidator : AbstractValidator<GetActorDetailQuery>
   {
        public GetActorDetailQeuryValidator()
        {
            RuleFor(query => query.ActorId).GreaterThan(0);
            
        }
   }
}