using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class CustomerCategories
    {
        public static void AddCustomerCategories(this MovieStoreDbContext context)
        {
                context.CustomerCategories.AddRange(
                    new CustomerCategory{ CustomerId = 1, CategoryId = 1},
                    new CustomerCategory{ CustomerId = 1, CategoryId = 2},
                    new CustomerCategory{ CustomerId = 1, CategoryId = 3},
                    new CustomerCategory{ CustomerId = 2, CategoryId = 2},
                    new CustomerCategory{ CustomerId = 2, CategoryId = 3},
                    new CustomerCategory{ CustomerId = 3, CategoryId = 1}

                );
        }
    }
}