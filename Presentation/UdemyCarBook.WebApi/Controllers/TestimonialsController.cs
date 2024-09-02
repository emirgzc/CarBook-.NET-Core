using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonailQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonailQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var values = await _mediator.Send(new GetTestimonaiByIdlQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonailCommands command)
        {
            await _mediator.Send(command);
            return Ok("Referans ekleme başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonailCommands command)
        {
            await _mediator.Send(command);
            return Ok("Referans güncelleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonailCommands(id));
            return Ok("Referans silme başarılı");
        }
    }
}
