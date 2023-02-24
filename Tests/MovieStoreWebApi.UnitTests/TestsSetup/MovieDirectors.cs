using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class MovieDirectors
    {
        public static void AddMovieDirectors(this MovieStoreDbContext context)
        {
            context.MovieDirectors.AddRange
            (
                new MovieDirector{ MovieId = 1, DirectorId = 1},
                new MovieDirector{ MovieId = 2, DirectorId = 2},
                new MovieDirector{ MovieId = 3, DirectorId = 3}
            );

        }
    }
}