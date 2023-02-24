using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace TestSetup
{
    public static class Categories
    {
        public static void AddCategories(this MovieStoreDbContext context)
        {
                context.Categories.AddRange(
                    new Category { CategoryName = "Suç/Gerilim"},
                    new Category { CategoryName = "Aksiyon"},
                    new Category { CategoryName = "Macera"}

                );
        }
    }
}