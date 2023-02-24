using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.Orders.AddRange
            (
                new Order { CustomerId = 1 , MovieId = 1, purchasedTime = new DateTime(2022, 07, 06) , IsActive = true },
                new Order { CustomerId = 2 , MovieId = 1, purchasedTime = new DateTime(2022, 12, 05) , IsActive = true },
                new Order { CustomerId = 3 , MovieId = 2, purchasedTime = new DateTime(2022, 08, 25) , IsActive = true }
                   
             );

        }
    }
}