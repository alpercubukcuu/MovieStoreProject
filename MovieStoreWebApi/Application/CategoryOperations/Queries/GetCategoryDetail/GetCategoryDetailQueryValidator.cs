using FluentValidation;

namespace MovieStoreWebApi.CategoryOperations.GetCategoryDetail
{
   public class GetCategoryDetailQeuryValidator : AbstractValidator<GetCategoryDetailQuery>
   {
        public GetCategoryDetailQeuryValidator()
        {
            RuleFor(query => query.CategoryId).GreaterThan(0);
            
        }
   }
}