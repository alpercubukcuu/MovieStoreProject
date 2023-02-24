using FluentValidation;

namespace MovieStoreWebApi.OrderOperations.GetOrderDetail
{
   public class GetOrderDetailQeuryValidator : AbstractValidator<GetOrderDetailQuery>
   {
        public GetOrderDetailQeuryValidator()
        {
            RuleFor(query => query.OrderId).GreaterThan(0);
            
        }
   }
}