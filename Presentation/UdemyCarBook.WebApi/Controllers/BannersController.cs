using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

        public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner Bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner Bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
           await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner Bilgisi güncellendi");
        }
    }
}
