using FluentValidation;

namespace MovieStoreWebApi.DirectorOperations.GetDirectorDetail
{
   public class GetDirectorDetailQeuryValidator : AbstractValidator<GetDirectorDetailQuery>
   {
        public GetDirectorDetailQeuryValidator()
        {
            RuleFor(query => query.DirectorId).GreaterThan(0);
            
        }
   }
}