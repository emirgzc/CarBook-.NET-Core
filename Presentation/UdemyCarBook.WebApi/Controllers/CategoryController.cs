using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCateogryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCateogryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCateogryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCateogryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCateogryCommandHandler;

        public CategoryController(CreateCategoryCommandHandler createCateogryCommandHandler, GetCategoryByIdQueryHandler getCateogryByIdQueryHandler, GetCategoryQueryHandler getCateogryQueryHandler, UpdateCategoryCommandHandler updateCateogryCommandHandler, RemoveCategoryCommandHandler removeCateogryCommandHandler)
        {
            _createCateogryCommandHandler = createCateogryCommandHandler;
            _getCateogryByIdQueryHandler = getCateogryByIdQueryHandler;
            _getCateogryQueryHandler = getCateogryQueryHandler;
            _updateCateogryCommandHandler = updateCateogryCommandHandler;
            _removeCateogryCommandHandler = removeCateogryCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCateogryQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCateogryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommands commands)
        {
            await _createCateogryCommandHandler.Handle(commands);
            return Ok("Kategori ekleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCateogryCommandHandler.Handle(new RemoveCategoryCommands(id));
            return Ok("Kategori silme başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommands commands)
        {
            await _updateCateogryCommandHandler.Handle(commands);
            return Ok("Kategori güncelleme başarılı");
        }
    }
}
