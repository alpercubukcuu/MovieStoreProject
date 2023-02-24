using FluentValidation;


namespace MovieStoreWebApi.CustomerOperations.DeleteCustomer
{
   public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
   {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.CustomerId).GreaterThan(0);

        }
   }
}