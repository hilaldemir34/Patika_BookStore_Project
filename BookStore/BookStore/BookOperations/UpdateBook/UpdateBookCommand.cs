using BookStore.DbOperations;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public UpdateBookInputModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            book.GenerateId = Model.GenerateId ?? book.GenerateId;
            book.PageCount = Model.PageCount ?? book.PageCount;
            book.PublishDate = Model.PublishDate ?? book.PublishDate;
            book.Title = Model.Title ?? book.Title;

            _dbContext.SaveChanges();
        }
    }
    public class UpdateBookInputModel
    {
        public int? GenerateId { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Title { get; set; }
    }


}
