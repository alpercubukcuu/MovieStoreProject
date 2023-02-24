using FluentValidation;

namespace MovieStoreWebApi.CustomerOperations.CreateCustomer
{
   public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
   {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
        }
   }
}