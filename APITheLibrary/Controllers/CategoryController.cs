using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITheLibrary.Controllers
{
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            return Ok(await categoryService.AddAsync(categoryDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            return Ok(await categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            return Ok(await categoryService.GetAsyncById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await categoryService.DeleteAsync(id);
            return Ok();
        }

    }
}
