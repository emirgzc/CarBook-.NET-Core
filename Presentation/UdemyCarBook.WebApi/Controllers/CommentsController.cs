using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonailQueries;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IGenericRepository<Comment> _repository;
		private readonly IMediator _mediator;
		public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
		{
			_repository = repository;
			_mediator = mediator;
		}
		[HttpGet]
		public IActionResult CommentList()
		{
			var values =  _repository.GetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateComment(Comment comment)
		{
			_repository.Create(comment);
			return Ok("Yorum ekleme başarılı");
		}
		[HttpPut]
		public IActionResult UpdateComment(Comment comment)
		{
			 _repository.Update(comment);
			return Ok("Yorum güncelleme başarılı");
		}
		[HttpDelete]
		public IActionResult RemoveComment(int id)
		{
			var value = _repository.GetById(id);
			_repository.Remove(value);
			return Ok("Yorum silme başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetComment(int id)
		{
			var values = _repository.GetById(id);
			return Ok(values);
		}
		[HttpGet("CommentListByBlog")]
		public IActionResult CommentListByBlog(int id)
		{
			var values = _repository.GetCommentsByBlogId(id);
			return Ok(values);
		}
		[HttpGet("CommentCountByBlog")]
		public IActionResult CommentCountByBlog(int id)
		{
			var values = _repository.GetCountCommentByBlog(id);
			return Ok(values);
		}
		[HttpPost("CreateCommentWithMediator")]
		public IActionResult CreateCommentWithMediator(CreateCommentCommand comment)
		{
			_mediator.Send(comment);
			return Ok("Yorum ekleme başarılı");
		}
	}
}
