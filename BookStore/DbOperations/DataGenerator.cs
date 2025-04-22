using Microsoft.EntityFrameworkCore;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(
                   new Book()
                   {
                       Title = "Lean Startup",
                       GenerateId=1,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 06, 12)
                   });

                context.SaveChanges();
            }
        }
    }
}
