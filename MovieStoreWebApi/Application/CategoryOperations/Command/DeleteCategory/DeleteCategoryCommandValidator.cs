using FluentValidation;


namespace MovieStoreWebApi.CategoryOperations.DeleteCategory
{
   public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
   {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(command => command.CategoryId).GreaterThan(0);

        }
   }
}