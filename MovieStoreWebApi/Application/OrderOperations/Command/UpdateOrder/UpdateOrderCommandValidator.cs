using FluentValidation;

namespace MovieStoreWebApi.OrderOperations.UpdateOrder
{
   public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
   {
        public UpdateOrderCommandValidator()
        {
            RuleFor(command=> command.Model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.Model.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
   }
}