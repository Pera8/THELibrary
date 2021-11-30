using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITheLibrary.Controllers
{
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        private readonly AuthorService authorService;
        public AuthorController(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthor(AuthorDTO authorDTO)
        {
            return Ok(await authorService.AddAsync(authorDTO));
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAuthor()
        {
            return Ok(await authorService.GetAllAsync());
        }

        [HttpGet("id:int")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            return Ok(await authorService.GetAsyncById(id));
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await authorService.DeleteAsync(id);
            return Ok();
        }

    }
}
