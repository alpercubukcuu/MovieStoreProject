using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class MovieActors
    {
        public static void AddMovieActors(this MovieStoreDbContext context)
        {
            context.MovieActors.AddRange
            (
                new MovieActor{ ActorId = 1, MovieId = 1},
                new MovieActor{ ActorId = 2, MovieId = 1},
                new MovieActor{ ActorId = 3, MovieId = 1},
                new MovieActor{ ActorId = 4, MovieId = 2},
                new MovieActor{ ActorId = 5, MovieId = 2},
                new MovieActor{ ActorId = 6, MovieId = 2},
                new MovieActor{ ActorId = 7, MovieId = 3},
                new MovieActor{ ActorId = 8, MovieId = 3},
                new MovieActor{ ActorId = 9, MovieId = 3}
            );

        }
    }
}