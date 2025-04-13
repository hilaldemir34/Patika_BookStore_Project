using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                Id=1,
                Title="Learn Startup",
                GenerateId=1,//Personal Growth
                PageCount=200,
                PublishDate=new DateTime(2001,06,12)

            },
           new Book
            {
                Id=2,
                Title="Learn Startup",
                GenerateId=2,//Personal Growth
                PageCount=200,
                PublishDate=new DateTime(2001,04,13)

           },
           new Book {
               Id=3,
               Title="Suc Ve Ceza",
               GenerateId=3,
               PageCount=300,
               PublishDate=new DateTime(2000,05,05)
        }

        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
    }

}

