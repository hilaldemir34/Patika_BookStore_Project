using BookStore.DbOperations;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookInputModel Model { get; set; }

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == Model.Id);
            if (book == null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
    public class DeleteBookInputModel
    {
        public int Id { get; set; }
    }
}
