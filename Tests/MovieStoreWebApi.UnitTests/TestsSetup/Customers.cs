using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
                context.Customers.AddRange(
                    new Customer { FirstName = "Aydın", LastName="Aktürk", Email="aydinaktürk@mail.com", Password="123456", RefreshToken=""},
                    new Customer { FirstName = "Melis", LastName="Ergin", Email="melisergin@mail.com", Password="654321", RefreshToken="" },
                    new Customer { FirstName = "Yunus", LastName="Emre", Email="yunusemre@mail.com", Password="124356", RefreshToken="" }

                );
        }
    }
}