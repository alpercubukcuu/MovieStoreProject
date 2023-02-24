using FluentValidation;

namespace MovieStoreWebApi.CategoryOperations.UpdateCategory
{
   public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
   {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(command => command.CategoryId).GreaterThan(0);
            RuleFor(command => command.Model.CategoryName).NotEmpty().MinimumLength(4);
           
        }
   }
}