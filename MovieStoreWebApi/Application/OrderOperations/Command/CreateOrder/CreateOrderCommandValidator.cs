using FluentValidation;

namespace MovieStoreWebApi.OrderOperations.CreateOrder
{
   public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
   {
        public CreateOrderCommandValidator()
        {
            RuleFor(command=> command.Model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.Model.MovieId).GreaterThan(0).NotNull().NotEmpty();
           
        }
   }
}