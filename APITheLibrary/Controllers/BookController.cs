using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITheLibrary.Controllers
{
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(BookDTO bookDTO)
        {
            return Ok(await bookService.AddAsync(bookDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            return Ok(await bookService.GetAllAsync());
        }

        [HttpGet("id:int")]
        public async Task<ActionResult> GetBookById (int id)
        {
            return Ok(await bookService.GetAsyncById(id));
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await bookService.DeleteAsync(id);
            return Ok();
        }
    }
}
