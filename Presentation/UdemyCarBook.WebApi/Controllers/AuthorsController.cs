﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthorsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> AuthorList()
		{
			var values = await _mediator.Send(new GetAuthorQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthor(int id)
		{
			var values = await _mediator.Send(new GetAuthorByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
		{
			await _mediator.Send(command);
			return Ok("Yazar ekleme başarılı");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
		{
			await _mediator.Send(command);
			return Ok("yazar güncelleme başarılı");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAuthor(int id)
		{
			await _mediator.Send(new RemoveAuthorCommand(id));
			return Ok("yazar silme başarılı");
		}
	}
}
