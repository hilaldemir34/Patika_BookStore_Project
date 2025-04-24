using BookStore.Common;
using BookStore.DbOperations;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GetBookByIdOutputModel? Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                return null;

            return new GetBookByIdOutputModel
            {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenerateId).ToString(),
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.ToString("dd/MM/yyyy")
            };
        }
    }
    public class GetBookByIdOutputModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }

}
