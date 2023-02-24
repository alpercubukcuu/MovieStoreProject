using FluentValidation;

namespace MovieStoreWebApi.CustomerOperations.UpdateCustomer
{
   public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
   {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(command => command.CustomerId).GreaterThan(0);
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
        }
   }
}