using FluentValidation;

namespace MovieStoreWebApi.CustomerOperations.GetCustomerDetail
{
   public class GetCustomerDetailQeuryValidator : AbstractValidator<GetCustomerDetailQuery>
   {
        public GetCustomerDetailQeuryValidator()
        {
            RuleFor(query => query.CustomerId).GreaterThan(0);
            
        }
   }
}