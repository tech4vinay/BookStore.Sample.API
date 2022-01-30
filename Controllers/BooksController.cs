using BookStore.API.Model;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet("AllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _booksRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _booksRepository.GetBookByIdAsync(id);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();

            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBook([FromBody] BookModel request)
        {
            var added = await _booksRepository.AddBookAsync(request);
            if (added)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity();
            }
        }

    }
}
