using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentACarController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RentACarController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetRentACarListByLocation(int locationID, bool available)
		{
			GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
			{
				LocationID = locationID,
				Available = available
			};
			var values = await _mediator.Send(getRentACarQuery);
			return Ok(values);
		}
	}
}
