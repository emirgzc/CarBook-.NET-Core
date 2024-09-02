using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarID(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
		[HttpGet("CarFeatureChangeAvailableToFalse")]
		public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
		{
			_mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
			return Ok("Güncelleme Yapıldı");
		}

		[HttpGet("CarFeatureChangeAvailableToTrue")]
		public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
		{
			_mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
			return Ok("Güncelleme Yapıldı");
		}
		[HttpPost]
		public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
		{
			await _mediator.Send(command);
			return Ok("ekleme başarılı");
		}
	}
}
