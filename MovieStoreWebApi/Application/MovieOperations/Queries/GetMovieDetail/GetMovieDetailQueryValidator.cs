using FluentValidation;

namespace MovieStoreWebApi.MovieOperations.GetMovieDetail
{
   public class GetMovieDetailQeuryValidator : AbstractValidator<GetMovieDetailQuery>
   {
        public GetMovieDetailQeuryValidator()
        {
            RuleFor(query => query.MovieId).GreaterThan(0);
            
        }
   }
}