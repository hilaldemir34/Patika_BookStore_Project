﻿using BookStore.DbOperations;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
       public CreateBookModel Model { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Book already exists!");
            book = new Book();
            book.Title = Model.Title;
            book.GenerateId = Model.GenreId;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
