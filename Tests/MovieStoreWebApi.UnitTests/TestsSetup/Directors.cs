using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange
            (
                new Director { FirstName="Rob", LastName="Cohen" },
                new Director { FirstName="Chad", LastName="Stahelski"},
                new Director { FirstName="David", LastName="Yates"}
                   
             );

        }
    }
}